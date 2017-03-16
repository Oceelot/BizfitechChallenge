using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Query.Endpoints.Programmer
{
    public interface IGetProgrammerByIdQuery
    {
        Domain.Programmers.Programmer Get(Guid id);
    }

    public class GetProgrammerByIdQuery : IGetProgrammerByIdQuery
    {
        private readonly IProfilesContext _profilesContext;

        public GetProgrammerByIdQuery(IProfilesContext profilesContext)
        {
            _profilesContext = profilesContext;
        }

        public Domain.Programmers.Programmer Get(Guid id)
        {
            return _profilesContext
                .GetEntities<Domain.Programmers.Programmer>()
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
