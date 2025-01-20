using MWTest.Datas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MWTest.Counters
{
    public class Counter : MonoBehaviour
    {
        private const string SAVE_NAME = "COUNTER_QUANTITY";

        [SerializeField] private TMP_Text _quantityText;
        [SerializeField] private Button _increaseButton;

        private int _quantity;

        private void Awake()
        {
            LoadQuantity();
            _increaseButton.onClick.AddListener(IncreaseQuantity);
        }

        private void OnApplicationQuit()
        {
            SaveQuantity();
        }

        private void IncreaseQuantity()
        {
            _quantity++;
            _quantityText.text = _quantity.ToString();
        }

        private void LoadQuantity()
        {
            if (!Saver.TryLoad(SAVE_NAME, out _quantity))
                _quantity = Settings.Get().StartingNumber;

            _quantityText.text = _quantity.ToString();
        }

        private void SaveQuantity()
        {
            Saver.Save(SAVE_NAME, _quantity);
        }
    }
}
