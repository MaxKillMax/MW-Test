namespace MWTest.Initializers
{
    public sealed class StartInitializer : Initializer
    {
        [Space]

        [SerializeField, Min(0)] private int _sceneIndex = 1;
        [SerializeField] private float _additionalWaitTime;

        [Space]

        [SerializeField] private UI.Loading _loading;

        private void Start()
        {
            StartCoroutine(WaitForLoad());
        }

        private IEnumerator WaitForLoad()
        {
            _loading.SetActive(true);

            CreateUpdater();
            InitializeTexts(TextsName);
            InitializeSettings(SettingsName);

            yield return StartCoroutine(WaitForInitializeAssets(AssetBundleRelativeName));
            yield return new WaitForSeconds(_additionalWaitTime);
            yield return StartCoroutine(WaitForLoadScene(_sceneIndex));
        }

        private static IEnumerator WaitForLoadScene(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

            while (!operation.isDone)
                yield return new WaitForEndOfFrame();

            Scene scene = SceneManager.GetSceneAt(0);
            SceneManager.UnloadSceneAsync(scene);
        }
    }
}
