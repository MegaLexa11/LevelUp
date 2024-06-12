using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeam.Team_Validator
{
    internal class QAAmountException : WorkersAmountException
    {
        public QAAmountException()
            : base("There should be at least 1 QA engineer of both manual and auto specializations in the team!")
        {

        }
    }
}
