using System.Diagnostics;


namespace MigrationTool
{
    internal abstract class DatabaseTemplate
    {
        protected const string Path = @"C:\Users\barte\source\repos\auction-app";

        public DatabaseTemplate(string databaseName, string startupProject, string infrastructure)
        {
            DatabaseName = databaseName;
            StartupProject = startupProject;
            Infrastructure = infrastructure;
        }

        public string DatabaseName { get; }
        private string Infrastructure { get; }
        private string StartupProject { get; }

        protected static void ExecuteCommand(string arguments)
        {
            Process process = new();
            process.StartInfo.FileName = "dotnet";
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            if (!string.IsNullOrEmpty(output))
                Console.WriteLine(output);

            if (!string.IsNullOrEmpty(error))
                Console.WriteLine(error);
        }

        protected static string ConstructArg(string arg)
        {
            return @$"{Path}\{arg}";
        }

        public virtual void AddMigration(string name = "Initial")
        {
            string command =
                $"dotnet ef migrations add {name} " +
                //$"--msbuildprojectextensionspath " +
                $"-p {ConstructArg(Infrastructure)} " +
                $"-s {ConstructArg(StartupProject)} " +
                $"-o {ConstructArg($"{Infrastructure}\\Migrations")}";

            ExecuteCommand(command);
        }

        public virtual void UpdateDatabase()
        {
            string command =
                $"dotnet ef update database " +
                $"--p {ConstructArg(Infrastructure)} " +
                $"--startup-project {ConstructArg(StartupProject)}";

            ExecuteCommand(command);
        }
    }
}
