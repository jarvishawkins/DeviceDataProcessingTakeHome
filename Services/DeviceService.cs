using DeviceDataProcessingTakeHome.Models;

namespace DeviceDataProcessingTakeHome.Services
{
    public interface IDeviceService
    {
        List<MergedData> MergeAndProcessData(Foo1 data);
    }

    public class DeviceService : IDeviceService
    {
        public List<MergedData> MergeAndProcessData(Foo1 data)
        {
            var mergedList = new List<MergedData>();

            foreach (var tracker in data.Trackers)
            {
                var temperatureCrumbs = tracker.Sensors.FirstOrDefault(s => s.Name == "Temperature")?.Crumbs;
                var humidityCrumbs = tracker.Sensors.FirstOrDefault(s => s.Name == "Humidty")?.Crumbs;

                var firstReading = temperatureCrumbs?.Min(c => c.CreatedDtm) ?? humidityCrumbs?.Min(c => c.CreatedDtm);
                var lastReading = temperatureCrumbs?.Max(c => c.CreatedDtm) ?? humidityCrumbs?.Max(c => c.CreatedDtm);

                mergedList.Add(new MergedData
                {
                    CompanyId = data.PartnerId,
                    CompanyName = data.PartnerName,
                    DeviceId = tracker.Id,
                    DeviceName = tracker.Model,
                    FirstReadingDtm = firstReading,
                    LastReadingDtm = lastReading,
                    TemperatureCount = temperatureCrumbs?.Count,
                    AverageTemperature = temperatureCrumbs?.Average(c => c.Value),
                    HumidityCount = humidityCrumbs?.Count,
                    AverageHumidity = humidityCrumbs?.Average(c => c.Value)
                });
            }

            return mergedList;
        }
    }
}
