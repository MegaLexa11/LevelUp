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
            var teamLeadsAmount = team.Workers.Count(worker => worker.GetType() == typeof(TeamLead));
            if (teamLeadsAmount != 0)
            {
                throw new TeamLeadsAmountException();
            }

            var analyticsAmount = team.Workers.Count(worker => worker.GetType() == typeof(Analytic));
            if (analyticsAmount != 1)
            {
                throw new AnalyticsAmountException();
            }

            var qaEngineers = team.Workers
                .Where(worker => worker.GetType() == typeof(QAEngineer))
                .Select(worker => (QAEngineer)worker);
            var manualQAAmount = qaEngineers.Count(worker => worker.Specialization == QASpecialization.Manual);
            var autoQAAmount = qaEngineers.Count(worker => worker.Specialization == QASpecialization.Auto);
            if (manualQAAmount < 1 && autoQAAmount < 1)
            {
                throw new QAAmountException();
            }

            var developers = team.Workers
                .Where(worker => worker.GetType() == typeof(Developer))
                .Select(worker => (Developer)worker);
            var backendAmount = developers.Count(worker => worker.Specialization == DeveloperSpecialization.Backend);
            if (backendAmount > 3)
            {
                throw new BackendDevelopersAmountException();
            }

            var webDevelopersAmount = developers.Count(worker => worker.Specialization == DeveloperSpecialization.Web);
            if (webDevelopersAmount >= 1 && webDevelopersAmount <= 2)
            {
                throw new WebDevelopersAmountException();
            }

            var androidDevelopersAmount = developers.Count(worker => worker.Specialization == DeveloperSpecialization.Android);
            var iosDevelopersAmount = developers.Count(worker => worker.Specialization == DeveloperSpecialization.IOS);
            if (androidDevelopersAmount != 1 && iosDevelopersAmount != 1)
            {
                throw new MobileDevelopersAmountException();
            }
        }
    }
}
