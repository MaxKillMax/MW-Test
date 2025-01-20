using System;
using UnityEngine;

namespace MWTest.UI
{
    public class Loading : MonoBehaviour
    {
        [SerializeField, Range(0, 360)] private float _rotationSpeed;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            Time.OnUpdate += OnUpdate;
        }

        private void OnDisable()
        {
            Time.OnUpdate -= OnUpdate;
        }

        public void SetActive(bool value) => gameObject.SetActive(value);

        private void OnUpdate()
        {
            Vector3 currentRotation = _transform.localRotation.eulerAngles;
            float applyingRotation = _rotationSpeed * Time.Delta;

            _transform.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z - applyingRotation);
        }
    }
}
