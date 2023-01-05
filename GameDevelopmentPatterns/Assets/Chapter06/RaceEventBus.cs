using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Chapter.EventBus
{
    public class RaceEventBus : MonoBehaviour
    {
        private static readonly IDictionary<RaceEventType, UnityEvent> Events = new Dictionary<RaceEventType, UnityEvent>();

        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out var thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }

        public static void Unsubscribe(RaceEventType eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out var thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(RaceEventType eventType)
        {
            if (Events.TryGetValue(eventType, out var thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}
