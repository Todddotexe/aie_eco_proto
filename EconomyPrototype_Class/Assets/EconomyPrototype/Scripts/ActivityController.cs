namespace EconomyPrototype {

    using Cinemachine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
	using TMPro;
    using UnityEngine;

    public class ActivityController : MonoBehaviour {


		#region Public Methods

		public CinemachineVirtualCamera GetVCam() {
            return m_VCam;
		}

		public void Deactivate() {
			m_PlaybackControls.SetActive(false);
			Stop();
		}

		public void Activate() {
			m_PlaybackControls.SetActive(true);
		}

		public void Stop() {
			Debug.Log("Stop");
			m_IsPlaying = false;
			PlaybackTime = 0;
		}

		public void Play() {
			Debug.Log("Play");
			m_IsPlaying = true;
			StartCoroutine(UpdatePlaybackTime());
		}

		public void Pause() {
			Debug.Log("Pause");
		}

		#endregion


		#region Unity Methods

		private void Start() {
			Deactivate();
		}

		#endregion


		#region Private Fields - Serialized

		[SerializeField]
		private CinemachineVirtualCamera m_VCam;

		[SerializeField]
		private GameObject m_PlaybackControls;

		[SerializeField]
		private TMP_Text m_PlaybackTimeText;

		#endregion


		#region Private Fields - Non Serialized

		[NonSerialized]
		private float m_PlaybackTime;

		[NonSerialized]
		private bool m_IsPlaying;

		#endregion


		#region Private Properties

		private float PlaybackTime {
			get {
				return m_PlaybackTime;
			}
			set {

				m_PlaybackTime = value;

				TimeSpan ts = TimeSpan.FromSeconds(m_PlaybackTime);
				m_PlaybackTimeText.text = string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds);

			}
		}

		#endregion


		#region Private Methods

		private IEnumerator UpdatePlaybackTime() {
			while (m_IsPlaying) {
				PlaybackTime += Time.deltaTime;
				yield return null;
			}
		}

		#endregion


	}

}