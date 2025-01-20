using System;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace MWTest.Datas
{
    [Serializable]
    public class Text
    {
        private static Text[] Texts;

        [JsonProperty("key"), SerializeField] public string Key;
        [JsonProperty("value"), SerializeField] public string Value;

        public static event Action OnInitialized;

        public static void Initialize(Text[] texts)
        {
            Texts = texts;
            OnInitialized?.Invoke();
        }

        public static string Get(string key)
        {
            try
            {
                Text text = Texts.First((t) => t.Key == key);
                return text.Value;
            }
            catch
            {
                Debug.LogWarning("Text exception with key: " + key);
                return null;
            }
        }
    }
}
