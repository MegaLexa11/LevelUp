using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeam.Team_Validator
{
    internal class WorkersAmountException(string description): Exception("Incorrect worker amount!")
    {
    }
}
