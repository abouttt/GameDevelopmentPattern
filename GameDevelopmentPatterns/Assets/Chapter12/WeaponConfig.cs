using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Decorator
{
    [CreateAssetMenu(fileName = "NewWeaponConfig", menuName = "Weapon/Config", order = 1)]
    public class WeaponConfig : ScriptableObject, IWeapon
    {
        [Range(0, 60)]
        [Tooltip("Increase rate of firing per second")]
        [SerializeField]
        public float rate;

        [Range(0, 50)]
        [Tooltip("Increase weapon range")]
        [SerializeField]
        public float range;

        [Range(0, 100)]
        [Tooltip("Increase weapon strength")]
        [SerializeField]
        public float strength;

        [Range(0, 5)]
        [Tooltip("Reduce cooldown duration")]
        [SerializeField]
        public float cooldown;

        public string attachmentName;
        public GameObject attachmentPrefab;
        public string attachmentDescription;

        public float Rate => rate;
        public float Range => range;
        public float Cooldown => cooldown;
        public float Strength => strength;
    }
}
