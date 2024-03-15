namespace MigrationTool
{
    internal class ActionServiceEF : DatabaseTemplate
    {
        public ActionServiceEF() :
            base("Auction Service EF Core", @$"WebApi\WebApi.csproj", "Infrastructure")
        { }
    }
}
