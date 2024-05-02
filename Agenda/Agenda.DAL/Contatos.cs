using Agenda.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;
        SqlConnection _con;

        public Contatos()
        {
            _strCon = @"Data Source=DESKTOP-98QJDF1\MSSQLSERVER01; Initial Catalog=Agenda; Integrated Security=True;";
            _con = new SqlConnection(_strCon);
        }

        public void Adicionar(Contato contato)
        {
            var sql = "";
            _con.Open();

            sql = String.Format("insert into Contato (Id, Nome) values ('{0}', '{1}');", contato.Id, contato.Nome);

            var cmd = new SqlCommand(sql, _con);

            cmd.ExecuteNonQuery();

            _con.Close();
        }

        public Contato Obter(Guid id)
        {
            var sql = "";

            _con.Open();

            sql = String.Format("select Id, Nome from Contato where Id = '{0}'", id);

            var cmd = new SqlCommand(sql, _con);

            var sqlDataReader = cmd.ExecuteReader();

            sqlDataReader.Read();

            var contato = new Contato()
            {
                Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                Nome = sqlDataReader["Nome"].ToString()
            };

            _con.Close();

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();
            var sql = "";

            _con.Open();

            sql = String.Format("select Id, Nome from Contato;");

            var cmd = new SqlCommand(sql, _con);

            var sqlDataReader = cmd.ExecuteReader();

            while(sqlDataReader.Read())
            {
                var contato = new Contato()
                {
                    Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                    Nome = sqlDataReader["Nome"].ToString()
                };

                contatos.Add(contato);
            }

            return contatos;
        }
    }
}
