using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeam.Team_Validator
{
    internal class MobileDevelopersAmountException : WorkersAmountException
    {
        public MobileDevelopersAmountException()
            : base("There should be 1 developer of both android and IOS specializations in the team!")
        {

        }
    }
}
