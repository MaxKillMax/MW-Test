using MWTest.Datas;
using UnityEngine;
using UnityEngine.UI;

namespace MWTest.UI
{
    [RequireComponent(typeof(RawImage))]
    public class RawImageSetter : MonoBehaviour
    {
        [SerializeField] private string _name;

        private RawImage _rawImage;

        private void Awake()
        {
            _rawImage = GetComponent<RawImage>();
            Load();

            Asset.OnInitialized += Load;
        }

        private void OnDestroy()
        {
            Asset.OnInitialized -= Load;
        }

        private void Load()
        {
            Asset.LoadAsync<Texture2D>(_name, OnDone);
        }

        private void OnDone(Texture2D texture)
        {
            if (_rawImage == null)
                return;

            _rawImage.texture = texture;
        }
    }
}
