namespace EconomyPrototype
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Cinemachine;

    public class ActivityController : MonoBehaviour
    {
        public CinemachineVirtualCamera GetVCam()
        {
            return vcamChild;
        }

        [SerializeField]
        private CinemachineVirtualCamera vcamChild;
    }
}
