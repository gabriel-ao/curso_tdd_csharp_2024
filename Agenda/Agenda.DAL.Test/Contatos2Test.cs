using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class Contatos2Test : BaseTest
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
        public void ObterTodosOsContatosTest()
        {
            // monta
            Contato contato1 = _fixture.Create<Contato>();
            Contato contato2 = _fixture.Create<Contato>();

            // executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);

            var result = _contatos.ObterTodos();
            var contatoResulta = result.Where(o => o.Id == contato1.Id).FirstOrDefault();

            // verifica
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(contatoResulta.Id, contato1.Id);
            Assert.AreEqual(contatoResulta.Nome, contato1.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
