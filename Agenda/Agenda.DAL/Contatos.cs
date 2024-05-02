using Agenda.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;

        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        public void Adicionar(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {
                var query = $"insert into Contato (Id, Nome) values ('{contato.Id}', '{contato.Nome}')";
                con.Execute(query);
            }
        }

        public Contato Obter(Guid id)
        {
            var contato = new Contato();

            using (var con = new SqlConnection(_strCon))
            {
                var query = $"select Id, Nome from Contato where Id = '{id}'";
                contato = con.Query<Contato>(query).FirstOrDefault();
            }

            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                var query = "select Id, Nome from Contato";
                contatos = con.Query<Contato>(query).ToList();
            }

            return contatos;
        }
    }
}
