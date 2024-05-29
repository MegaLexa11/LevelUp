using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeam.Team_Validator
{
    internal class AnalyticsAmountException : WorkersAmountException
    {
        public AnalyticsAmountException()
            : base("There should be only one Analytic in the team!")
        {

        }
    }
}
