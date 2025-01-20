using System;
using Newtonsoft.Json;
using UnityEngine;

namespace MWTest.Datas
{
    [Serializable]
    public class Settings
    {
        private static Settings Instance;

        [JsonProperty("startingNumber"), SerializeField] public int StartingNumber;

        public void Initialize() => Instance = this;

        public static Settings Get() => Instance;
    }
}
