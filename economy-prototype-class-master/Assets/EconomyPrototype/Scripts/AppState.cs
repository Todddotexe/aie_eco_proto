namespace EconomyPrototype {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// This is a <see cref="ScriptableObject"/> that will store 
    /// the application variables that define the app state
    /// </summary>
    [CreateAssetMenu(menuName = "Economy Prototype/Current Resources")]
    public class AppState : ScriptableObject {


        #region Public Fields
        /// <summary>
        /// The amount of resources that are available at any moment in the lifecycle of the app
        /// </summary>
        [Tooltip("The amount of resources that are available at any moment in the lifecycle of the app")]
        [SerializeField]
        public Resource Current;

        [SerializeField]
        public int CompletedActivities;

        #endregion


        #region Public Methods
        /// <summary>
        /// Resets the app state to the desired default values
        /// </summary>
        /// <remarks>
        /// Since the values of this scriptable object will change at runtime thus method will help us to keep the default 
        /// </remarks>
        public void Restore() {
            Current.A = 100;
            Current.B = 100;
            Current.C = 100;
            CompletedActivities = 0;
        }

        #endregion


        #region Unity Methods

        private void Awake() {
			Restore();
		}

		#endregion


	}

}