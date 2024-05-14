﻿using Agenda.DAL;
using Agenda.Domain;
using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repos.Test
{
    public class ITelefoneConstr
    {
        // Criar moq de Itelefone
        Mock<ITelefone> _mockTelefone = new Mock<ITelefone>();
        Fixture _fixture;

        protected ITelefoneConstr(Mock<ITelefone> mockTelefone, Fixture fixture)
        {
            _mockTelefone = mockTelefone;
            _fixture = fixture;
        }

        public static ITelefoneConstr Um()
        {
            return new ITelefoneConstr(new Mock<ITelefone>(), new Fixture());
        }
        
        public ITelefone Construir()
        {
            return _mockTelefone.Object;
        }

        public ITelefoneConstr Padrao()
        {
            _mockTelefone.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mockTelefone.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mockTelefone.SetupGet(o => o.ContatoId).Returns(_fixture.Create<Guid>());

            return this;
        }

        public ITelefoneConstr ComId(Guid id)
        {
            _mockTelefone.SetupGet(o => o.Id).Returns(id);
            return this;
        }

        public ITelefoneConstr ComNumero(string numero)
        {
            _mockTelefone.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }

        public ITelefoneConstr ComContatoId(Guid contatoId)
        {
            _mockTelefone.SetupGet(o => o.ContatoId).Returns(contatoId);
            return this;
        }


        //mTelefone.SetupGet(o => o.Id).Returns(telefoneId);
        //mTelefone.SetupGet(o => o.Numero).Returns("1234-1234");
        //mTelefone.SetupGet(o => o.ContatoId).Returns(contatoId);
    }
}
