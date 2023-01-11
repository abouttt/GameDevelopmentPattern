using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class CameraController : Observer
    {
        private bool _isTurboOn;
        private Vector3 _initPosition;
        private float _shakeMagnitude = 0.1f;
        private BikeController _bikeController;

        private void OnEnable()
        {
            _initPosition = gameObject.transform.localPosition;
        }

        private void Update()
        {
            if (_isTurboOn)
            {
                gameObject.transform.localPosition = _initPosition + (Random.insideUnitSphere * _shakeMagnitude);
            }
            else
            {
                gameObject.transform.localPosition = _initPosition;
            }
        }

        public override void Notify(Subject subject)
        {
            if (!_bikeController)
            {
                _bikeController = subject.GetComponent<BikeController>();
            }

            if (_bikeController)
            {
                _isTurboOn = _bikeController.IsTurboOn;
                _isTurboOn = _bikeController.IsTurboOn;
            }
        }
    }
}