using System;
using Domain.Programmers;
using Moq;
using NUnit.Framework;
using Query.Endpoints.Programmer;

namespace Query.Tests.Unit.Endpoints.Programmers
{
    [TestFixture]
    public class ProgrammerServiceTests
    {
        private ProgrammerResponse _response;
        private Guid _expectedProgrammerId;

        private Mock<IGetProgrammerByIdQuery> _mockGetProgrammerByIdQuery;
        private Programmer _expectedProgrammer;
        private string _expectedName;
        private string _expectedBio;
        private string _expectedBlogUrl;

        [SetUp]
        public void GivenAProgrammersService_WhenAServiceRequestToGetAllProgrammersIsMade()
        {
            _expectedProgrammerId = Guid.NewGuid();
            _expectedName = Guid.NewGuid().ToString();
            _expectedBio = Guid.NewGuid().ToString();
            _expectedBlogUrl = Guid.NewGuid().ToString();

            _expectedProgrammer = new Programmer
            {
                Id = _expectedProgrammerId,
                Name = _expectedName,
                Bio = _expectedBio,
                BlogUrl = _expectedBlogUrl
            };

            _mockGetProgrammerByIdQuery = new Mock<IGetProgrammerByIdQuery>();
            _mockGetProgrammerByIdQuery
                .Setup(query => query.Get(It.IsAny<Guid>()))
                .Returns(_expectedProgrammer);

            var programmersService = new ProgrammerService(_mockGetProgrammerByIdQuery.Object);
            _response = programmersService.Get(new ProgrammerRequest
            {
                ProgrammerId = _expectedProgrammerId
            });
        }

        [Test]
        public void ThenTheGetProgrammerByIdQueryIsCalled()
        {
            _mockGetProgrammerByIdQuery.Verify(query => query.Get(It.IsAny<Guid>()));
        }

        [Test]
        public void ThenTheCorrectProgrammerIdIsReturned()
        {
            Assert.That(_response.Programmer.Id, Is.EqualTo(_expectedProgrammerId));
        }

        [Test]
        public void ThenTheCorrectProgrammerNameIsReturned()
        {
            Assert.That(_response.Programmer.Name, Is.EqualTo(_expectedName));
        }

        [Test]
        public void ThenTheCorrectProgrammerBioIsReturned()
        {
            Assert.That(_response.Programmer.Bio, Is.EqualTo(_expectedBio));
        }

        [Test]
        public void ThenTheCorrectProgrammerBlogUrlIsReturned()
        {
            Assert.That(_response.Programmer.BlogUrl, Is.EqualTo(_expectedBlogUrl));
        }
    }
}