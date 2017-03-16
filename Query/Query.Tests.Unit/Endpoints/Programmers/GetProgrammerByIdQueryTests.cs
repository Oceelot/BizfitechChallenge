using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Domain.Programmers;
using Moq;
using NUnit.Framework;
using Query.Endpoints.Programmer;

namespace Query.Tests.Unit.Endpoints.Programmers
{
    [TestFixture]
    public class GetProgrammerByIdQueryTests
    {
        private Guid _expectedProgrammerId;      
        private string _expectedBlogUrl;
        private string _expectedBio;
        private string _expectedName;

        private Programmer _actualProgrammer;
        private Programmer _expectedProgrammer;
        private Programmer _notExpectedProgrammer;
        private Mock<IProfilesContext> _mockProfilesContext;

        [SetUp]
        public void GivenAGetProgrammerByIdQuery_WhenACallToGetIsMade()
        {
            _expectedProgrammerId = Guid.NewGuid();

            _expectedBlogUrl = Guid.NewGuid().ToString();
            _expectedBio = Guid.NewGuid().ToString();
            _expectedName = Guid.NewGuid().ToString();

            _expectedProgrammer = new Programmer
            {
                Id = _expectedProgrammerId,
                Name = _expectedName,
                Bio = _expectedBio,
                BlogUrl = _expectedBlogUrl
            };

            _notExpectedProgrammer = new Programmer
            {
                Id = Guid.NewGuid(),
                Bio = Guid.NewGuid().ToString(),
                BlogUrl = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };

            var programmersList = new List<Programmer>
            {
                _notExpectedProgrammer,
                _expectedProgrammer
            }.AsQueryable();

            _mockProfilesContext = new Mock<IProfilesContext>();
            _mockProfilesContext
                .Setup(context => context.GetEntities<Programmer>())
                .Returns(programmersList);

            var query = new GetProgrammerByIdQuery(_mockProfilesContext.Object);
            _actualProgrammer = query.Get(_expectedProgrammerId);
        }

        [Test]
        public void ThenTheCorrectProgrammerIdIsReturned()
        {
            Assert.That(_actualProgrammer.Id, Is.EqualTo(_expectedProgrammerId));
        }

        [Test]
        public void ThenTheCorrectProgrammerNameIsReturned()
        {
            Assert.That(_actualProgrammer.Name, Is.EqualTo(_expectedName));
        }

        [Test]
        public void ThenTheCorrectProgrammerBioIsReturned()
        {
            Assert.That(_actualProgrammer.Bio, Is.EqualTo(_expectedBio));
        }

        [Test]
        public void ThenTheCorrectProgrammerBlogUrlIsReturned()
        {
            Assert.That(_actualProgrammer.BlogUrl, Is.EqualTo(_expectedBlogUrl));
        }
    }
}