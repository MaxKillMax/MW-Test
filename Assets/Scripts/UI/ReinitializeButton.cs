using MWTest.Initializers;
using UnityEngine;
using UnityEngine.UI;

namespace MWTest.UI
{
    [RequireComponent(typeof(Button))]
    public class ReinitializeButton : MonoBehaviour
    {
        [SerializeField] private Reinitializer _reinitializer;

        private void Awake()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _reinitializer.Initialize();
        }
    }
}
