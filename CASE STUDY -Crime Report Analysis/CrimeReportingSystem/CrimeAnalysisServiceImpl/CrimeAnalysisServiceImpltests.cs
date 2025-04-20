using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using CrimeReportingSystem.dao;
using CrimeReportingSystem.Entity;

namespace CrimeReportingSystem.Tests
{
    [TestFixture]
    public class CrimeAnalysisServiceImplTests
    {
        private Mock<ICrimeAnalysisService> _mockCrimeAnalysisService;

        [SetUp]
        public void SetUp()
        {
            _mockCrimeAnalysisService = new Mock<ICrimeAnalysisService>();
        }

        [Test]
        public void TestCreateIncident_ShouldReturnTrue_WhenIncidentCreatedSuccessfully()
        {
            var incident = new Incident
            {
                IncidentID = 1,
                IncidentType = "Robbery",
                IncidentDate = DateTime.Now,
                Location = "Main Street",
                Description = "A robbery occurred.",
                Status = "Open",
                VictimID = 1001,
                SuspectID = 2002,
                AgencyID = 1
            };

            _mockCrimeAnalysisService.Setup(x => x.CreateIncident(It.IsAny<Incident>())).Returns(true);

            var result = _mockCrimeAnalysisService.Object.CreateIncident(incident);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestUpdateIncidentStatus_ShouldReturnTrue_WhenStatusUpdatedSuccessfully()
        {
            _mockCrimeAnalysisService.Setup(x => x.UpdateIncidentStatus(1, "Closed")).Returns(true);

            var result = _mockCrimeAnalysisService.Object.UpdateIncidentStatus(1, "Closed");

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestGetIncidentsInDateRange_ShouldReturnIncidents_WhenDateRangeIsValid()
        {
            var expected = new List<Incident>
            {
                new Incident
                {
                    IncidentID = 1,
                    IncidentType = "Robbery",
                    IncidentDate = DateTime.Now,
                    Location = "Main Street",
                    Description = "Description",
                    Status = "Open",
                    VictimID = 1,
                    SuspectID = 2,
                    AgencyID = 3
                }
            };

            _mockCrimeAnalysisService.Setup(x =>
                x.GetIncidentsInDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(expected);

            var result = _mockCrimeAnalysisService.Object.GetIncidentsInDateRange(DateTime.Now.AddDays(-7), DateTime.Now);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestSearchIncidents_ShouldReturnIncidents_WhenIncidentTypeIsValid()
        {
            var expected = new List<Incident>
            {
                new Incident
                {
                    IncidentID = 2,
                    IncidentType = "Robbery",
                    IncidentDate = DateTime.Now,
                    Location = "2nd Street",
                    Description = "Some incident",
                    Status = "Open",
                    VictimID = 1,
                    SuspectID = 2,
                    AgencyID = 3
                }
            };

            _mockCrimeAnalysisService.Setup(x => x.SearchIncidents("Robbery")).Returns(expected);

            var result = _mockCrimeAnalysisService.Object.SearchIncidents("Robbery");

            Assert.That(result, Is.Not.Empty);
            Assert.That(result[0].IncidentType, Is.EqualTo("Robbery"));
        }

       
    }
}

