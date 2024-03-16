using System.Diagnostics.CodeAnalysis;

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
