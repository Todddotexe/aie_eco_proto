namespace EconomyPrototype
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Cinemachine;

    public class ActivitiesManager : MonoBehaviour
    {
        private ActivityController currentActivity;
        public int priorityLow = 1;
        public int priorityHigh = 3;

        public void Activity_PointerClick(ActivityController newActivityController)
        {
            if (newActivityController == CurrentactivityController)
            {
                CurrentactivityController = null;
            }
            else
            {
                CurrentactivityController = newActivityController;
            }
        }
       
        private ActivityController CurrentactivityController
        {
            get
            {
                return currentActivity;
            }
            set
            {
                if (currentActivity != null)
                {
                    currentActivity.GetVCam().Priority = priorityLow;
                }
                currentActivity = value;
                if (currentActivity != null)
                {
                    currentActivity.GetVCam().Priority = priorityHigh;
                }
            }
        }
    }
}
