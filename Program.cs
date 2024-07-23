using DeviceDataProcessingTakeHome.Models;
using DeviceDataProcessingTakeHome.Repositories;
using DeviceDataProcessingTakeHome.Services;
using DeviceDataProcessingTakeHome.Utils;

namespace DeviceDataProcessingTakeHome
{
    public class Program
    {
        static void Main(string[] args)
        {
            var foo1Repository = new Foo1Repository("./DeviceDataFoo1.json");
            var foo2Repository = new Foo2Repository("./DeviceDataFoo2.json");
            
            var mergeDeviceService = new MergeService<Foo1>().MergeData(foo1Repository.GetData());
            var mergeTrackerService = new MergeService<Foo2>().MergeData(foo2Repository.GetData());

            DataSerializer.SaveToJsonFile(mergeDeviceService?.Concat(mergeTrackerService), "./MergedData.json");
        }
    }
}