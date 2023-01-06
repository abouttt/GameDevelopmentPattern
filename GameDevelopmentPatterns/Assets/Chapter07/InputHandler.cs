using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Command
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        private bool _isReplaying;
        private bool _isRecording;
        private BikeController _bikeController;
        private Command _buttonA;
        private Command _buttonD;
        private Command _buttonW;

        private void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _bikeController = FindObjectOfType<BikeController>();

            _buttonA = new TurnLeft(_bikeController);
            _buttonD = new TurnRight(_bikeController);
            _buttonW = new ToggleTurbo(_bikeController);
        }

        private void Update()
        {
            if (!_isReplaying && _isRecording)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    _invoker.ExcuteCommand(_buttonA);
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    _invoker.ExcuteCommand(_buttonD);
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    _invoker.ExcuteCommand(_buttonW);
                }
            }
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Start Recording"))
            {
                _bikeController.ResetPosition();
                _isReplaying = false;
                _isRecording = true;
                _invoker.Record();
            }

            if (GUILayout.Button("Stop Recording"))
            {
                _bikeController.ResetPosition();
                _isRecording = false;
            }

            if (!_isRecording)
            {
                if (GUILayout.Button("Start Replay"))
                {
                    _bikeController.ResetPosition();
                    _isRecording = false;
                    _isReplaying = true;
                    _invoker.Replay();
                }
            }
        }
    }
}
