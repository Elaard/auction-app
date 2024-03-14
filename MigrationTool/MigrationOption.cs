using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool
{
    internal class MigrationOption
    {
        [SetsRequiredMembers]
        public MigrationOption(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Id { get; set; }
        public required string Name { get; set; }
    }
}
