using LnW.DotNet.PmsApp.Entities;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace LnW.DotNet.PmsApp.Storage
{
    public class FileStorage<T> : IStorage<T> where T : class
    {
        private readonly string filePath;
        public FileStorage(IOptions<FilePathSetting> settingOptions)
        {
            this.filePath = settingOptions.Value.FilePath;
        }
        public async Task<List<T>> LoadDataAsync()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using Stream stream = File.OpenRead(filePath);
                    List<T>? records = await JsonSerializer.DeserializeAsync<List<T>>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return records ?? [];
                }
                else
                    return new();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task WriteDataAsync(IEnumerable<T> data)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string updatedData = JsonSerializer.Serialize(data, options);
                await File.AppendAllTextAsync(filePath, updatedData);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
