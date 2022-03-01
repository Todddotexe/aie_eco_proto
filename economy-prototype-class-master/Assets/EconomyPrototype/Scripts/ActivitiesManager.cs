namespace EconomyPrototype {

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Cinemachine;
    using UnityEngine.UI;

    public class ActivitiesManager : MonoBehaviour {


        #region Public Fields

        /// <summary>
        /// A reference to the <see cref="EconomyPrototype.AppState"/>
        /// </summary>
        [Tooltip("A reference to the AppState asset")]
        [SerializeField]
        public AppState AppState;

        [SerializeField]
        public AppSettings AppSettings;

        [SerializeField]
        public Image Clock;

        public GameEndPopUp GameEndPopUp;

		#endregion


		#region Public Methods

		public void CancelCurrentActivity() {
            CurrentActivityController = null;
		}

		public void Activity_PointerClick(ActivityController newActivityController) {
            if(newActivityController == CurrentActivityController) {
                // If the new activity is the current one we go back to the main camera
                CurrentActivityController = null;
            } else {
                // If the new activity is different from the current one, we choose its camera
                CurrentActivityController = newActivityController;
			}
		}


        #endregion


        #region Unity Methods

        private void Start()
        {
            GameEndPopUp.gameObject.SetActive(false);
            StartCoroutine(UpdateSession());
        }

		private void OnDestroy() {
            AppState.Restore();
		}

		#endregion


		#region Private Fields

		[NonSerialized]
        private ActivityController m_CurrentActivity;

		#endregion


		#region Private Properties

		private ActivityController CurrentActivityController {
            get {
                return m_CurrentActivity;
			}
			set {

                // If there is one current activity, I want to deactivate its camera
				if (m_CurrentActivity != null) {
                    m_CurrentActivity.GetVCam().Priority = 9;
                    m_CurrentActivity.Deactivate();
                }

                // Now we are receiving the new activity which can be an activity or null
                m_CurrentActivity = value;

                // If the new activity is not null, its camera becomes the one with the highest priority
                if(m_CurrentActivity != null) {
                    m_CurrentActivity.GetVCam().Priority = 11;
                    m_CurrentActivity.Activate();
                }

                // The main camera has a priority of 10 which we are using as a middle point
                // The logic here is to change the priority of the activity cameras to be either
                // higher or lower than the main vcam (9 or 11)

                // In this example, The Current camera is the activity #1 vcam
                //------------------------------------------------
                // P 11         [A2 VCam]
                //------------------------------------------------
                // P 10                 [M VCam]
                //------------------------------------------------
                // P 9      [A1 VCam]           [A3 VCam] 
                //------------------------------------------------


                // In this example, The Current camera is null, so the main camera renders the scene
                //------------------------------------------------
                // P 11         
                //------------------------------------------------
                // P 10                 [M VCam]
                //------------------------------------------------
                // P 9      [A1 VCam]   [A2 VCam]   [A3 VCam] 
                //------------------------------------------------

            }
        }

        #endregion

        #region Private Methods
        private IEnumerator UpdateSession()
        {
            //This is the time variable
            float time = 0;
            //The while loop will repeat itself until the time reaches the session duration
            while(time < AppSettings.sessionDuration)
            {
                // Increase the time here
                time = time + Time.deltaTime;

                float progress = time / AppSettings.sessionDuration;
                Clock.fillAmount = progress;
                // Displaying Time increase in the console
                Debug.Log(time);
                // Make the while loop wait for one frame to continue
                yield return null;
            }
            Debug.Log("Time is Over");
            GameEndPopUp.gameObject.SetActive(true);
            GameEndPopUp.ShowMessage("Time is Over! You Suck!");
        }
        #endregion
    }

}
