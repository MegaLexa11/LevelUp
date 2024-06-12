using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeam.Team_Validator
{
    internal class TeamLeadsAmountException : WorkersAmountException
    {
        public TeamLeadsAmountException()
            : base("There should be only one Teamlead in the team!")
        {

        }
    }
}
