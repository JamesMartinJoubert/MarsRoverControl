using MarsRover.Services;
using FluentAssertions;

namespace MarsRover.Tests.Tests
{
    [TestClass]
    public sealed class MarsGridUtilitiesTests
    {
        [TestMethod]
        public void MarsGridUtilities_AreGridSizesValid_Is_True()
        {
            var areGridSizesValid = MarsGridUtilities.AreGridSizesValid(1,1);

            areGridSizesValid.Should().BeTrue();
        }

        [TestMethod]
        public void MarsGridUtilities_AreGridSizesValid_Is_False()
        {
            var areGridSizesValid = MarsGridUtilities.AreGridSizesValid(0, 1);

            areGridSizesValid.Should().BeFalse();
        }

        [TestMethod]
        public void MarsGridUtilities_GenerateMarsGrid_ShouldGenerateOneCell()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(1, 1);

            marsGrid.LongLength.Should().Be(1);
        }

        [TestMethod]
        public void MarsGridUtilities_GenerateMarsGrid_ShouldGenerateNineCell()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(3, 3);

            marsGrid.LongLength.Should().Be(9);
        }
    }
}
