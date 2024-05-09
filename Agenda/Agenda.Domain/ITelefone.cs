using System;

namespace Agenda.Domain
{
    public interface ITelefone
    {
        Guid Id { get; set; }
        int Numero { get; set; }
        Guid ContatoId { get; set; }

    }
}
