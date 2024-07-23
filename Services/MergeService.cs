using DeviceDataProcessingTakeHome.Models;

namespace DeviceDataProcessingTakeHome.Services
{
    public class MergeService<T>
    {
        public List<MergedData> MergeData<T>(T fooData)
        {
            if (fooData == null) return new();

            if(fooData is Foo1)
            {
                return new DeviceService().MergeAndProcessData(fooData as Foo1);
            }

            if(fooData is Foo2)
            {
                return new TrackerService().MergeAndProcessData(fooData as Foo2);
            }

            return new();
        }
    }
}
