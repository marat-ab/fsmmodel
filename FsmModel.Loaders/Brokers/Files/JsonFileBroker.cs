using System.IO;
using System.Text.Json;

namespace FsmModel.Loaders.Brokers.Files
{
    public class JsonFileBroker<T> : IFileBroker<T>
    {
        public T? Load(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException($"File: {fileName}");

            T? model = JsonSerializer.Deserialize<T>(File.ReadAllText(fileName));

            return model;
        }
    }
}
