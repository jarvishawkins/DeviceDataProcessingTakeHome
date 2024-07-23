using DeviceDataProcessingTakeHome.Models;
using DeviceDataProcessingTakeHome.Repositories;
using DeviceDataProcessingTakeHome.Services;
using Xunit;

namespace DeviceDataProcessingTakeHome.Tests
{
    public class MergeServiceTests
    {
        [Fact]
        public void MergeData_ShouldReturnCorrectMergedData()
        {
            // Arrange
            var foo1Repository = new Foo1Repository("./DeviceDataFoo1.json");
            var foo2Repository = new Foo2Repository("./DeviceDataFoo2.json");

            var mergeDeviceService = new MergeService<Foo1>().MergeData(foo1Repository.GetData());
            var mergeTrackerService = new MergeService<Foo2>().MergeData(foo2Repository.GetData());

            // Act
            var mergedData = mergeDeviceService?.Concat(mergeTrackerService);

            // Assert
            Assert.NotNull(mergedData);
            Assert.NotEmpty(mergedData);
        }

        [Fact]
        public void MergeData_ShouldReturnFoo1Data()
        {
            // Arrange
            var foo1Repository = new Foo1Repository("./DeviceDataFoo1.json");
            var foo2Repository = new Foo2Repository("./DeviceDataFoo2.json");


            // Act
            var foo1Data = foo1Repository.GetData();
            var foo2Data = foo2Repository.GetData();

            // Assert
            Assert.NotNull(foo1Data);
            Assert.NotEmpty(foo1Data.Trackers);

            Assert.NotNull(foo2Data);
            Assert.NotEmpty(foo2Data.Devices);
        }
    }
}
