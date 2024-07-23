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
    public class Foo2Repository : IRepository<Foo2>
    {
        private readonly string _filePath;

        public Foo2Repository(string filePath)
        {
            _filePath = filePath;
        }
        public Foo2 GetData()
        {
            var json = File.ReadAllText(_filePath);

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new CustomDateTimeConverter());

            return JsonSerializer.Deserialize<Foo2>(json, options);
        }
    }
}
