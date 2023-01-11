using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Visitor
{
    public class ClientVisitor : MonoBehaviour
    {
        public PowerUp enginePowerUP;
        public PowerUp shieldPowerUP;
        public PowerUp weaponPowerUP;

        private BikeController _bikeController;

        private void Start()
        {
            _bikeController = gameObject.AddComponent<BikeController>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("PowerUp Shield"))
            {
                _bikeController.Accept(shieldPowerUP);
            }

            if (GUILayout.Button("PowerUp Engine"))
            {
                _bikeController.Accept(enginePowerUP);
            }

            if (GUILayout.Button("PowerUp Weapon"))
            {
                _bikeController.Accept(weaponPowerUP);
            }
        }
    }
}
