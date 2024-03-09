using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Sort
{
    public static class PathManager
    {
        private static string _appDataPath = AppDomain.CurrentDomain.BaseDirectory;

        private static string _folderPath = Path.Combine(_appDataPath, "AppData");

        private static string _filePath = Path.Combine(_folderPath, "pathData.json");

        private static bool _createAppDataFolder()
        {
            if (Directory.Exists(_folderPath) == false)
            {
                Directory.CreateDirectory(_folderPath);
                return false;
            }
            return true;
        }

        public static void SaveChanges(UserPathData Info)
        {
            _createAppDataFolder();
            string newData = JsonConvert.SerializeObject(Info);
            File.WriteAllText(_filePath, newData);
        }

        public static UserPathData Load()
        {
            if (_createAppDataFolder() == false)
            {
                return new UserPathData();
            }
            string jsonContents = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(jsonContents))
            {
                return new UserPathData();
            }
            return JsonConvert.DeserializeObject<UserPathData>(jsonContents);
        }
        public static void DeleteInvalidItems(UserPathData Info)
        {
            if (Info.IsEmtpy()) return;

            Info.RemoveInvalidEntries();
        }

    }
}
