using UnityEngine;

namespace MWTest
{
    public class Updater : MonoBehaviour
    {
        private readonly Time _time = new();

        private void Update()
        {
            _time.Update();
        }
    }
}
