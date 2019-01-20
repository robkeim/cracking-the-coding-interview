using System;
using System.Collections.Generic;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class OverlappingPartiesTests
    {
        private readonly DateTime _janFirst = new DateTime(2000, 1, 1);

        [TestMethod]
        public void FindMostOverlappingParties_WithOneParty_ReturnsStartDateOfFirstParty()
        {
            // Arrange
            var parties = new List<Party>
            {
                new Party(_janFirst, _janFirst.AddDays(1))
            };

            // Act
            var actual = OverlappingParties.FindMostOverlappingParties(parties);

            // Assert
            Assert.AreEqual(_janFirst, actual);
        }

        [TestMethod]
        public void FindMostOverlappingParties_WithOneOverlap_ReturnsStartDateOfOverlap()
        {
            // Arrange
            var parties = new List<Party>
            {
                new Party(_janFirst, _janFirst.AddDays(2)),
                new Party(_janFirst.AddDays(1), _janFirst.AddDays(3))
            };

            // Act
            var actual = OverlappingParties.FindMostOverlappingParties(parties);

            // Assert
            Assert.AreEqual(_janFirst.AddDays(1), actual);
        }

        [TestMethod]
        public void FindMostOverlappingParties_WithOverlapAtSameTime_DoesNotReturnOverlap()
        {
            // Arrange
            var parties = new List<Party>
            {
                new Party(_janFirst, _janFirst.AddDays(1)),
                new Party(_janFirst.AddDays(1), _janFirst.AddDays(2))
            };

            // Act
            var actual = OverlappingParties.FindMostOverlappingParties(parties);

            // Assert
            Assert.AreEqual(_janFirst, actual);
        }

        [TestMethod]
        public void FindMostOverlappingParties_WithSameDate_ReturnsStartDateOfParties()
        {
            // Arrange
            var parties = new List<Party>
            {
                new Party(_janFirst, _janFirst.AddDays(1)),
                new Party(_janFirst, _janFirst.AddDays(1))
            };

            // Act
            var actual = OverlappingParties.FindMostOverlappingParties(parties);

            // Assert
            Assert.AreEqual(_janFirst, actual);
        }

        [TestMethod]
        public void FindMostOverlappingParties_WithTwoDisjointPartyGroups_ReturnsStartDateOfLargerGroup()
        {
            // Arrange
            var parties = new List<Party>
            {
                new Party(_janFirst, _janFirst.AddDays(1)),
                new Party(_janFirst.AddDays(2), _janFirst.AddDays(4)),
                new Party(_janFirst.AddDays(3), _janFirst.AddDays(5))
            };

            // Act
            var actual = OverlappingParties.FindMostOverlappingParties(parties);

            // Assert
            Assert.AreEqual(_janFirst.AddDays(3), actual);
        }

        [TestMethod]
        public void FindMostOverlappingParties_NullInput_ThrowsException()
        {
            // Arrange

            // Act
            void action() => OverlappingParties.FindMostOverlappingParties(null);

            // Assert
            TestHelpers.AssertExceptionThrown(action, typeof(ArgumentNullException));
        }

        [TestMethod]
        public void FindMostOverlappingParties_NoParties_ThrowsException()
        {
            // Arrange
            var parties = new List<Party>();

            // Act
            void action() => OverlappingParties.FindMostOverlappingParties(parties);

            // Assert
            TestHelpers.AssertExceptionThrown(action, typeof(ArgumentException));
        }

        [TestMethod]
        public void FindMostOverlappingParties_InvalidPartyDates_ThrowsException()
        {
            // Arrange
            var parties = new List<Party>
            {
                new Party(_janFirst, _janFirst.AddDays(-1))
            };

            // Act
            void action() => OverlappingParties.FindMostOverlappingParties(parties);

            // Assert
            TestHelpers.AssertExceptionThrown(action, typeof(ArgumentOutOfRangeException));
        }
    }
}
