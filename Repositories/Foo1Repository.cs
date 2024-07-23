using DeviceDataProcessingTakeHome.Models;
using DeviceDataProcessingTakeHome.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Repositories
{
    public class Foo1Repository : IRepository<Foo1>
    {
        private readonly string _filePath;

        public Foo1Repository(string filePath)
        {
            _filePath = filePath;
        }

        public Foo1 GetData()
        {
            var json = File.ReadAllText(_filePath);

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new CustomDateTimeConverter());

            return JsonSerializer.Deserialize<Foo1>(json, options);
        }
    }
}
