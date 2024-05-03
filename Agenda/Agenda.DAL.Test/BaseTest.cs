using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class BaseTest
    {
        private string _script;
        private string _con;
        private string _catalogTest;

        public BaseTest()
        {
            _script = @"DBAgendaTest_Create.sql";   
            _con = ConfigurationManager.ConnectionStrings["conSetUpTest"].ConnectionString;
            _catalogTest = ConfigurationManager.ConnectionStrings["conSetUpTest"].ProviderName;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            CreateDBTest();
        }

        [OneTimeTearDown] public void OneTimeTearDown() 
        {
            DeleteDBTest();
        }


        //:setvar DatabaseName "Database1"
        //:setvar DefaultFilePrefix "Database1"
        //:setvar DefaultDataPath ""
        //:setvar DefaultLogPath ""

        private void CreateDBTest()
        {
            var appBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //System.IO.FileNotFoundException : Não foi possível localizar o arquivo 'R:\documentos\github\curso_tdd_csharp_2024\Agenda\Agenda.DAL.Test\bin\Debug\ProjetoDB_Create.sql'.
            using (var con = new SqlConnection(_con))
            {
                con.Open();
                var scriptSql = File
                    .ReadAllText($@"{appBase}\{_script}")
                    .Replace("$(DefaultDataPath)", $@"{appBase}")
                    .Replace("$(DefaultLogPath)", $@"{appBase}")
                    .Replace("$(DefaultFilePrefix)", _catalogTest)
                    .Replace("$(DatabaseName)", _catalogTest)
                    .Replace("WITH (DATA_COMPRESSION = PAGE)", string.Empty)
                    .Replace("SET NOEXEC ON", string.Empty)
                    .Replace("GO\r\n", "|");

                ExecuteScriptSql(con, scriptSql);
            }
        }

        private void ExecuteScriptSql(SqlConnection con, string scriptSql)
        {
            using (var cmd = con.CreateCommand())
            {
                foreach (var sql in scriptSql.Split('|'))
                {
                    cmd.CommandText = sql;

                    //Essa linha irá ignora as linhas que contem ':' como :setvar ou :on error etc
                    //No nosso caso, não irá fazer diferença.
                    if (sql.Contains(':'))
                        continue;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(sql);
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }



        private void DeleteDBTest()
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();

                using (var cmd = con.CreateCommand())
                {

                    //                    cmd.CommandText = $@" 
                    //                        USE [master];
                    //DECLARE @kill varchar(8000)

                    //                    ";

                    //Irá mudar para Base Master
                    cmd.CommandText = $@"USE [master]";
                    cmd.ExecuteNonQuery();

                    //String com a quey para buscar todas as sessões da base de teste.
                    cmd.CommandText = $@"SELECT session_id AS Id
                                         FROM sys.dm_exec_sessions
                                         WHERE database_id = db_id('{_catalogTest}')";

                    //Irá realizar a leitura na Base Master
                    var reader = cmd.ExecuteReader();

                    //Criação de uma lista para pôr os Ids
                    var ids = new List<int>();

                    //Leitura dos Ids porque pode ocorrer de ter mais de uma sessão para AgendaTest
                    while (reader.Read())
                    {
                        ids.Add(reader.GetInt16(0));
                    }
                    //Fechando o SqlDataReader
                    reader.Close();

                    //Irá dar o comando kill para cada id
                    foreach (var id in ids)
                    {
                        cmd.CommandText = $@"kill {id}";
                        cmd.ExecuteNonQuery();
                    }

                    //Irá dropar a Base de teste.
                    cmd.CommandText = $"DROP DATABASE {_catalogTest}";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
