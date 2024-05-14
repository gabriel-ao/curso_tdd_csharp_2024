using Agenda.Domain;
using AutoFixture;
using Moq;
using System;

namespace Agenda.Repos.Test
{
    public class IContatoConstr
    {
        private readonly Mock<IContato> _mockIContato;
        private readonly Fixture _fixture;
        protected IContatoConstr(Mock<IContato> mockIContato, Fixture fixture)
        {
            _mockIContato = mockIContato;
            _fixture = fixture;
        }

        public static IContatoConstr Um()
        {
            return new IContatoConstr(new Mock<IContato>(), new Fixture());
        }

        public IContato Construir()
        {
            return _mockIContato.Object;
        }

        public Mock<IContato> Obter()
        {
            return _mockIContato;
        }

        public IContatoConstr ComNome(string nome)
        {
            _mockIContato.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }

        public IContatoConstr ComId(Guid id)
        {
            _mockIContato.SetupGet(o => o.Id).Returns(id);
            return this;
        }
    }
}
