using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool
{
    internal static class MigrationOptions
    {
        public static List<MigrationOption> List = new()
        {
            new MigrationOption( OptionTypes.AddMigration, "Add a migration" ),
            new MigrationOption( OptionTypes.UpdateDatabase, "Update database" )
        };
    }
}
