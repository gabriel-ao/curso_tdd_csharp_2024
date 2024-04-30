//using NUnit.Framework;
using NUnit.Framework;
using System;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
        }

        [Test]
        public void IncluirContatoTest()
        {
            // monta
            string id = Guid.NewGuid().ToString();
            string nome = "Kaleb";
            // executa
            _contatos.Adicionar(id, nome);

            var varTrue = true;
            // verifica
            Assert.Equals(true, varTrue);
        }

        [Test]
        public void ObterContatoTest()
        {

        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }

    }
}
