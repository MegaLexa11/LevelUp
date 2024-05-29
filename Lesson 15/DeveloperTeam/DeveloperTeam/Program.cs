using DeveloperTeam;
using DeveloperTeam.Team_Validator;

Developer dev1 = new Developer("Nick", DeveloperSpecialization.Android, Level.Junior);
Developer dev2 = new Developer("Bob", DeveloperSpecialization.IOS, Level.Middle);
Developer dev3 = new Developer("Ann", DeveloperSpecialization.Backend, Level.Senior);
Developer dev4 = new Developer("Bill", DeveloperSpecialization.Web, Level.Junior);
Analytic dev5 = new Analytic("Tasha", AnalyticSpecialization.BA, Level.Middle);
//Analytic dev6 = new Analytic("Kelly", AnalyticSpecialization.SA, Level.Junior);
QAEngineer dev7 = new QAEngineer("Richard", QASpecialization.Manual, Level.Junior);
QAEngineer dev8 = new QAEngineer("Tom", QASpecialization.Auto, Level.Junior);
TeamLead dev9 = new TeamLead("Jerry");

Worker[] workers = [dev1, dev2, dev3, dev4, dev5, dev7, dev8];
//Worker[] workers = [dev1, dev2, dev3, dev4, dev5, dev6, dev7, dev8];

Team SuperDuperTeam = new Team(dev9, workers);

SuperDuperTeam.PrintTeamInfo();

TeamValidator.Validate(SuperDuperTeam);