using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Chapter.State
{
    public class BikeController : MonoBehaviour
    {
        public float MaxSpeed = 2.0f;
        public float TurnDistance = 2.0f;
        public float CurrentSpeed { get; set; }
        public Direction CurrentTurnDirection { get; private set; }

        private IBikeState _startState;
        private IBikeState _stopState;
        private IBikeState _turnState;

        private BikeStateContext _bikeStateContext;

        private void Start()
        {
            _bikeStateContext = new(this);

            _startState = gameObject.AddComponent<BikeStartState>();
            _stopState = gameObject.AddComponent<BikeStopState>();
            _turnState = gameObject.AddComponent<BikeTurnState>();

            _bikeStateContext.Transition(_stopState);
        }

        public void StartBike()
        {
            _bikeStateContext.Transition(_startState);
        }

        public void StopBike()
        {
            _bikeStateContext.Transition(_stopState);
        }

        public void TurnBike(Direction direction)
        {
            CurrentTurnDirection = direction;
            _bikeStateContext.Transition(_turnState);
        }
    }
}
