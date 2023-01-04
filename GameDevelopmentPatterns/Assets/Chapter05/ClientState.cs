using Chapter.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.State
{
    public class ClientState : MonoBehaviour
    {
        private BikeController _bikeController;

        private void Start()
        {
            _bikeController = FindObjectOfType<BikeController>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Start Bike"))
                _bikeController.StartBike();
            if (GUILayout.Button("Turn Left"))
                _bikeController.TurnBike(Direction.Left);
            if (GUILayout.Button("Turn Right"))
                _bikeController.TurnBike(Direction.Right);
            if (GUILayout.Button("Stop Bike"))
                _bikeController.StopBike();
        }
    }
}
