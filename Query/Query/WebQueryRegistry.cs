using DataAccess;
using StructureMap;

namespace Query
{
    public class WebQueryRegistry : Registry
    {
        public WebQueryRegistry()
        {
            Scan(scanner => {
                scanner.AssemblyContainingType<Program>();
                scanner.AssemblyContainingType<IProfilesContext>();
                scanner.WithDefaultConventions();
            });
        }
    }
}