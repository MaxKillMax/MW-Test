using System;
using UnityEngine;

namespace MWTest.Datas
{
    public class Asset
    {
        private static AssetBundle AssetBundle;

        public static event Action OnInitialized;

        public static void Initialize(AssetBundle assetBundle)
        {
            AssetBundle = assetBundle;
            OnInitialized?.Invoke();
        }

        public static async void LoadAsync<T>(string name, Action<T> onDone) where T : UnityEngine.Object
        {
            AssetBundleRequest request = AssetBundle.LoadAssetAsync<T>(name);
            await request;

            if (request.asset == null)
                Debug.LogWarning("Requested asset is null! Name is:" + name);
            else
                onDone?.Invoke(request.asset as T);
        }
    }
}
