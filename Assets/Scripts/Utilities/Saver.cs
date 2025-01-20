using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace MWTest
{
    public static class Saver
    {
        private static string PathStart => Application.persistentDataPath + '/';

        public static bool TryLoad<T>(string name, out T saving)
        {
            string path = PathStart + name;

            if (!File.Exists(path))
            {
                saving = default;
                return false;
            }

            try
            {
                string text = File.ReadAllText(path);

                saving = JsonConvert.DeserializeObject<T>(text);
                return true;
            }
            catch (System.Exception exception)
            {
                Debug.LogWarning(exception.Message);

                saving = default;
                return false;
            }
        }

        public static void Save<T>(string name, T saving)
        {
            string path = PathStart + name;
            string text = JsonConvert.SerializeObject(saving);

            try
            {
                File.WriteAllText(path, text);
            }
            catch (System.Exception exception)
            {
                Debug.LogWarning(exception.Message);
            }
        }
    }
}
