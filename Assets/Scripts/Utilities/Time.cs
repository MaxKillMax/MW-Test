using System;

namespace MWTest
{
    public class Time
    {
        public static float Delta;

        /// <summary>
        /// MonoBehaviours subcribed on this action will have OnUpdate() method instead of Unity Update()
        /// </summary>
        public static event Action OnUpdate;

        public void Update()
        {
            Delta = UnityEngine.Time.deltaTime;

            OnUpdate?.Invoke();
        }
    }
}
