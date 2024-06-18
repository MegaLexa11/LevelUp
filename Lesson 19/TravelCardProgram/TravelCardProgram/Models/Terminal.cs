using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models
{
    internal class Terminal
    {
        public Guid Id { get; set; }
        // Тип транспорта, в котором терминал
        public TransportType TransportType { get; set; }

        public IEnumerable<Trip> Trips { get; init; } = default!;
    }
}
