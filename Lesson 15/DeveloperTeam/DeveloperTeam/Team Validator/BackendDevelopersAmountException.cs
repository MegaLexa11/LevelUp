using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeam.Team_Validator
{
    internal class BackendDevelopersAmountException : WorkersAmountException
    {
        public BackendDevelopersAmountException()
            : base("There should be less then 3 Backend developers in the team!")
        {

        }
    }
}
