//using NUnit.Framework;
using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void AdicionarContatoTest()
        {
            // monta
            Contato contato = _fixture.Create<Contato>();

            // executa
            _contatos.Adicionar(contato);

            // verifica
            Assert.IsTrue(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            Contato contatoResultado = new Contato();

            // monta
            Contato contato = _fixture.Create<Contato>();

            // executa
            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            // verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }

    }
}
