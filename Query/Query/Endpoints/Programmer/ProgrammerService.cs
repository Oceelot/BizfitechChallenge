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

        public ProgrammerResponse Get(ProgrammerRequest request)
        {
            return new ProgrammerResponse
            {
                Programmer = _getProgrammerByIdQuery.Get(request.ProgrammerId)
            };
        }
    }
}