using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCardProgram.Models
{
    internal class Coefficient
    {
        public Guid Id { get; set; }
        // Наименование коэффициента - для обращения к нему
        public string Name { get; set; }
        // Значение коэффициента
        public double Value { get; set; }
        // Длительность действия, если есть
        public int? durationMinutes { get; set; }
    }
}
