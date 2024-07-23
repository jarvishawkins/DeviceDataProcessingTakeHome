using DeviceDataProcessingTakeHome.Models;

namespace DeviceDataProcessingTakeHome.Services
{

    public interface ITrackerService
    {
        List<MergedData> MergeAndProcessData(Foo2 data);
    }

    public class TrackerService : ITrackerService
    {
        public List<MergedData> MergeAndProcessData(Foo2 data)
        {
            var mergedList = new List<MergedData>();


            foreach (var device in data.Devices)
            {
                var temperatureData = device.SensorData.Where(s => s.SensorType == "TEMP");
                var humidityData = device.SensorData.Where(s => s.SensorType == "HUM");

                var firstReading = temperatureData.Min(s => s.DateTime);
                var lastReading = temperatureData.Max(s => s.DateTime);

                mergedList.Add(new MergedData
                {
                    CompanyId = data.CompanyId,
                    CompanyName = data.Company,
                    DeviceId = device.DeviceID,
                    DeviceName = device.Name,
                    FirstReadingDtm = firstReading,
                    LastReadingDtm = lastReading,
                    TemperatureCount = temperatureData.Count(),
                    AverageTemperature = temperatureData.Average(s => s.Value),
                    HumidityCount = humidityData.Count(),
                    AverageHumidity = humidityData.Average(s => s.Value)
                });
            }

            return mergedList;
        }
    }
}
