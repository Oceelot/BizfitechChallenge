using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Endpoints.Programmer
{
    public interface IGetProgrammerByIdQuery
    {
        Domain.Programmers.Programmer Get(Guid id);
    }

    public class GetProgrammerByIdQuery : IGetProgrammerByIdQuery
    {
        public GetProgrammerByIdQuery()
        {
            
        }

        public Domain.Programmers.Programmer Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
