using MigrationTool;



var databaseHandler = new ActionServiceEF();

Console.WriteLine($"Choose an option for: \n -> {databaseHandler.DatabaseName}");
Console.WriteLine("_____________________________________________________\n");


while (true)
{
    foreach(var option in  MigrationOptions.List)
    {
        Console.WriteLine($"{option.Id}. {option.Name}");
    }
    Console.WriteLine($"{OptionTypes.End}. End program");

    Console.WriteLine("_____________________________________________________\n");

    Console.Write("Option: ");
    
    var input = Console.ReadLine();


    switch(input)
    {
        case OptionTypes.AddMigration:
            databaseHandler.AddMigration();
            break;
        case OptionTypes.UpdateDatabase:
            databaseHandler.UpdateDatabase(); 
            break;
        case OptionTypes.End:
            Environment.Exit(0);
            break;
        default:
            break;
    }
}