using MigrationTool;
using System;
using System.Diagnostics;


string path = @"C:\Users\barte\source\repos\auction-app";

string startupProject = @$"{path}\WebApi\WebApi.csproj";

string infrastructurePath = @$"{path}\Infrastructure";

Console.WriteLine("Choose an option");

while (true)
{
    foreach(var option in  MigrationOptions.List)
    {
        Console.WriteLine($"{option.Id}. {option.Name}");
    }
    Console.WriteLine("_____________________________________________________");

    Console.Write("Option: ");
    var input = Console.ReadLine();

    Action result = input switch
    {
        OptionTypes.AddMigration => AddMigration,
        OptionTypes.UpdateDatabase => UpdateDatabase,
        _ => Exit
    };

    result();
}

void ExecuteCommand(string command)
{
    Process process = new();
    process.StartInfo.FileName = "dotnet";
    process.StartInfo.Arguments = command;
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

void Exit()
{
    Environment.Exit(0);
}

void AddMigration()
{
    string command = $"dotnet ef add migrations Initial --msbuildprojectextensionspath --p {infrastructurePath} --startup-project {startupProject} --o {infrastructurePath}\\Migrations";
    ExecuteCommand(command);
}

void UpdateDatabase()
{
    string command = $"dotnet ef update database --p {infrastructurePath} --startup-project {startupProject}";
    ExecuteCommand(command);
}