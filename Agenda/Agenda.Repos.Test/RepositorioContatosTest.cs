using Agenda.DAL;
using Agenda.Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Agenda.Repos.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;

        [SetUp]
        public void SetUpAttribute()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }

        [Test]
        public void DeveSerPossivelObterContatoComListaTelefone()
        {
            List<ITelefone> lstTelefone = new List<ITelefone>();
            var telefoneId = Guid.NewGuid();
            var contatoId = Guid.NewGuid();
            // monta
            // criar moq de Icontato
            Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(o => o.Id).Returns(contatoId);
            mContato.SetupGet(o => o.Nome).Returns("João");
            mContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>())
                .Callback<List<ITelefone>>(p => lstTelefone = p);
            
            // moq da função ObterPorId de IContatos
            _contatos.Setup(o => o.Obter(contatoId)).Returns(mContato.Object);

            // Criar moq de Itelefone
            Mock<ITelefone> mTelefone = new Mock<ITelefone>();
            mTelefone.SetupGet(o => o.Id).Returns(telefoneId);
            mTelefone.SetupGet(o => o.Numero).Returns("1234-1234");
            mTelefone.SetupGet(o => o.ContatoId).Returns(contatoId);

            // Moq da função ObterTodosDoContato de Itelefones
            _telefones.Setup(o => o.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mTelefone.Object });

            // executa
            // Chamar o metodo ObterPorId de repositorioContatos
            IContato contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mContato.Setup(o => o.Telefones).Returns(lstTelefone);

            // verifica
            //Verificar se o Contato retornado contem os mesmos dados do moq Icontato com a lista de Telefones do Moq Itelefone
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            Assert.AreEqual(1, contatoResultado.Telefones.Count);
            Assert.AreEqual(mTelefone.Object.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mTelefone.Object.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }

    }
}
