//using NUnit.Framework;
using Agenda.Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
        }

        [Test]
        public void AdicionarContatoTest()
        {
            // monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Kaleb"
            };

            // executa
            _contatos.Adicionar(contato);

            // verifica
            Assert.IsTrue(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            var contatoResultado = new Contato();

            // monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "magali0205"
            };

            // executa
            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            // verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            // monta
            var contato1 = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "monica0205"
            };

            var contato2 = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "cebolinha0205"
            };

            // executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);

            var result = _contatos.ObterTodos();
            var contatoResulta = result.Where(o => o.Id == contato1.Id).FirstOrDefault();

            // verifica
            Assert.IsTrue(result.Count() > 1);
            Assert.AreEqual(contatoResulta.Id, contato1.Id);
            Assert.AreEqual(contatoResulta.Nome, contato1.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }

    }
}
