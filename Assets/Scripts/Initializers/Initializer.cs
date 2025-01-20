namespace MWTest.Initializers
{
    public abstract class Initializer : MonoBehaviour
    {
        private static Updater _updater;

        [SerializeField] protected string AssetBundleRelativeName;
        [SerializeField] protected string SettingsName;
        [SerializeField] protected string TextsName;

        protected static IEnumerator WaitForInitializeAssets(string assetBundleName)
        {
            string path = Path.Combine(Application.streamingAssetsPath, assetBundleName);

            AssetBundle.UnloadAllAssetBundles(true);
            AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);

            while (!request.isDone)
                yield return new WaitForEndOfFrame();

            Asset.Initialize(request.assetBundle);
        }

        protected static void InitializeTexts(string textsName)
        {
            List<Text> texts = LoadResource<List<Text>>(textsName);
            Text.Initialize(texts.ToArray());
        }

        protected static void InitializeSettings(string settingsName)
        {
            Settings settings = LoadResource<Settings>(settingsName);
            settings.Initialize();
        }

        protected static void CreateUpdater()
        {
            if (_updater != null)
                return;

            GameObject gameObject = new(nameof(Updater));
            _updater = gameObject.AddComponent<Updater>();
            DontDestroyOnLoad(gameObject);
        }

        private static T LoadResource<T>(string path)
        {
            TextAsset asset = Resources.Load(path) as TextAsset;
            T resource = JsonConvert.DeserializeObject<T>(asset.text);
            return resource;
        }
    }
}
