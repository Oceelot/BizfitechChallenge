using System;
using ServiceStack;

namespace Query.Endpoints.Programmer
{
    public class ProgrammerService : Service
    {
        private readonly IGetProgrammerByIdQuery _getProgrammerByIdQuery;

        public ProgrammerService(IGetProgrammerByIdQuery getProgrammerByIdQuery)
        {
            _getProgrammerByIdQuery = getProgrammerByIdQuery;
        }

        public ProgrammerResponse Get(ProgrammerRequest programmerRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}