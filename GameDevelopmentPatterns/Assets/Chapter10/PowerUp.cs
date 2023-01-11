using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

namespace Chapter.Visitor
{
    [CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
    public class PowerUp : ScriptableObject, IVisitor
    {
        public string powerUpName;
        public GameObject powerUpPrefab;
        public string powerUpDescription;

        [Tooltip("Fully heal shield")]
        public bool healShield;

        [Range(0.0f, 50.0f)]
        [Tooltip("Boost turbo settings up to increments of 50/mph")]
        public float turboBoost;

        [Range(0, 25)]
        [Tooltip("Boost weapon range in increments of up to 25 units")]
        public int weapnRange;

        [Range(0.0f, 50.0f)]
        [Tooltip("Boost weapon strength in increments of up to 50%")]
        public float weaponStrength;

        public void Visit(BikeShield bikeShield)
        {
            if (healShield)
            {
                bikeShield.health = 100.0f;
            }
        }

        public void Visit(BikeEngine bikeEngine)
        {
            float boost = bikeEngine.turboBoost += turboBoost;

            if (boost < 0.0f)
            {
                bikeEngine.turboBoost = 0.0f;
            }

            if (boost >= bikeEngine.maxTurboBoost)
            {
                bikeEngine.turboBoost = bikeEngine.maxTurboBoost;
            }
        }

        public void Visit(BikeWeapon bikeWeapon)
        {
            int range = bikeWeapon.range += weapnRange;

            if (range >= bikeWeapon.maxRange)
            {
                bikeWeapon.range = bikeWeapon.maxRange;
            }
            else
            {
                bikeWeapon.range = range;
            }

            float strength = bikeWeapon.strength += Mathf.Round(bikeWeapon.strength * weaponStrength / 100.0f);

            if (strength >= bikeWeapon.maxStrength)
            {
                bikeWeapon.strength = bikeWeapon.maxStrength;
            }
            else
            {
                bikeWeapon.strength = strength;
            }
        }
    }
}
