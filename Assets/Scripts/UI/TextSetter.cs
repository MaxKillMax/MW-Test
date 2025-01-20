using TMPro;
using UnityEngine;

namespace MWTest.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextSetter : MonoBehaviour
    {
        [SerializeField] private string _key;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            UpdateText();

            Datas.Text.OnInitialized += UpdateText;
        }

        private void OnDestroy()
        {
            Datas.Text.OnInitialized -= UpdateText;
        }

        private void UpdateText()
        {
            _text.text = Datas.Text.Get(_key);
        }
    }
}
