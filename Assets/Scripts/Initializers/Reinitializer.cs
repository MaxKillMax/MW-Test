using System.Collections;

namespace MWTest.Initializers
{
    public sealed class Reinitializer : Initializer
    {
        private bool _inProcess;

        public void Initialize()
        {
            if (_inProcess)
                return;

            StartCoroutine(WaitForLoad());
        }

        private IEnumerator WaitForLoad()
        {
            _inProcess = true;

            InitializeTexts(TextsName);
            InitializeSettings(SettingsName);

            yield return StartCoroutine(WaitForInitializeAssets(AssetBundleRelativeName));

            _inProcess = false;
        }
    }
}
