using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeam.Team_Validator
{
    internal class WebDevelopersAmountException : WorkersAmountException
    {
        public WebDevelopersAmountException()
            : base("There should be 1 or 2 Backend developers in the team!")
        {

        }
    }
}
