using System;
using ServiceStack;

namespace Query.Endpoints.Programmer
{
    [Route("/programmers/{programmerId}", "GET")]
    public class ProgrammerRequest
    {
        public Guid ProgrammerId { get; set; }
    }
}