using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTeam.Team_Validator
{
    internal static class TeamValidator
    {
        public static void Validate(Team team)
        {
            string exceptionMessage;

            var teamLeadsAmount = team.Workers.Count(worker => worker.GetType() == typeof(TeamLead));
            if (teamLeadsAmount != 0)
            {
                exceptionMessage = "There should be 1 Teamlead in a team!";
                throw new WorkersAmountException(exceptionMessage);
            }

            int analyticsLimit = 1;
            var analyticsAmount = team.Workers.Count(worker => worker.GetType() == typeof(Analytic));
            if (analyticsAmount != analyticsLimit)
            {
                exceptionMessage = $"There should be {analyticsLimit} analytic(s) in a team!";
                throw new WorkersAmountException(exceptionMessage);
            }


            var minManualQA = 1;
            var minAutoAQ = 1;
            var qaEngineers = team.Workers
                .Where(worker => worker.GetType() == typeof(QAEngineer))
                .Select(worker => (QAEngineer)worker);
            var manualQAAmount = qaEngineers.Count(worker => worker.Specialization == QASpecialization.Manual);
            var autoQAAmount = qaEngineers.Count(worker => worker.Specialization == QASpecialization.Auto);
            if (manualQAAmount < minManualQA && autoQAAmount < minAutoAQ)
            {
                exceptionMessage = $"There should be more than {minManualQA} manual QA Engineers and more than {minAutoAQ} auto QA Engineers!";
                throw new WorkersAmountException(exceptionMessage);
            }

            var developers = team.Workers
                .Where(worker => worker.GetType() == typeof(Developer))
                .Select(worker => (Developer)worker);

            var maxBackendAmount = 3;
            var backendAmount = developers.Count(worker => worker.Specialization == DeveloperSpecialization.Backend);
            if (backendAmount > maxBackendAmount)
            {
                exceptionMessage = $"There should be less than {maxBackendAmount} Backend developers!";
                throw new WorkersAmountException(exceptionMessage);
            }

            var minWebAmount = 1;
            var maxWebAmount = 2;
            var webDevelopersAmount = developers.Count(worker => worker.Specialization == DeveloperSpecialization.Web);
            if (webDevelopersAmount < 1 || webDevelopersAmount > 2)
            {
                exceptionMessage = $"There should be more than {minWebAmount} and less than {maxWebAmount} Web developers!";
                throw new WorkersAmountException(exceptionMessage);
            }

            var androidDevelopersLimit = 1;
            var iosDevelopersLimit = 1;
            var androidDevelopersAmount = developers.Count(worker => worker.Specialization == DeveloperSpecialization.Android);
            var iosDevelopersAmount = developers.Count(worker => worker.Specialization == DeveloperSpecialization.IOS);
            if (androidDevelopersAmount != androidDevelopersLimit && iosDevelopersAmount != iosDevelopersLimit)
            {
                exceptionMessage = $"There should be {androidDevelopersAmount} Android developer(s) and {iosDevelopersAmount} IOS developer(s)!";
                throw new WorkersAmountException(exceptionMessage);
            }
        }
    }
}
