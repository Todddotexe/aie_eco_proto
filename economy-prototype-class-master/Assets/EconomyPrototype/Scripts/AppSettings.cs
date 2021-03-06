namespace EconomyPrototype
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Economy Prototype/App Settings")]
    public class AppSettings : ScriptableObject
    {
        /// <summary>
        /// The duration of the session.
        /// </summary>
        [Tooltip("The duration of the session")]
        [SerializeField]
        public float sessionDuration;

        /// <summary>
        /// The minimum activities the player must run in order not to lose
        /// </summary>
        [Tooltip("The minimum activities the player must run in order not to lose")]
        [SerializeField]
        public float MinActivities;
    }
}
