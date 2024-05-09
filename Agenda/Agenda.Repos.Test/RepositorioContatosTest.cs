using Agenda.DAL;
using Moq;
using NUnit.Framework;

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
			_repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object) ;
		}

		[Test]
		public void DeveSerPossivelObterContatoComListaTelefone()
		{
			// monta
				// criar moq de Icontato
				// moq da função ObterPorId de IContatos
				// Criar moq de Itelefone
				// Moq da função ObterTodosDoContato de Itelefones

			// executa
				// Chamar o metodo ObterPorId de repositorioContatos

			// verifica
				//Verificar se o Contato retornado contem os mesmos dados do moq Icontato com a lista de Telefones do Moq Itelefone

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
