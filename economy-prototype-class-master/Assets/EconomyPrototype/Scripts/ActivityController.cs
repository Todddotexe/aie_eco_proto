namespace EconomyPrototype {

    using Cinemachine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
	using TMPro;
    using UnityEngine;

    public class ActivityController : MonoBehaviour {


		#region Public Fields

		[SerializeField]
		public AppState AppState;

		[SerializeField]
		public ActivityProfile Profile;

		[SerializeField]
		public ResourcesDisplay ResourcesDisplay;

		#endregion


		#region Public Methods

		public CinemachineVirtualCamera GetVCam() {
            return m_VCam;
		}
		/// <summary>
		/// Deactives the activity playback controls
		/// </summary>
		/// <remarks>
		/// This will stop the activity
		/// </remarks>
		public void Deactivate() {
			m_PlaybackControls.SetActive(false);
			m_PauseButton.SetActive(false);
			Stop();
		}
		/// <summary>
		/// Actives playback controls
		/// </summary>
		public void Activate() {
			m_PlaybackControls.SetActive(true);
		}
		/// <summary>
		/// Stops the activity from running
		/// </summary>
		/// <remarks>
		/// It makes the consumption of the resources stop
		/// It resets the time of the playback
		/// </remarks>
		public void Stop() {
			Debug.Log("Stop");
			m_IsPlaying = false;
			m_PlayButton.SetActive(true);
			m_PauseButton.SetActive(false);
			PlaybackTime = 0;
		}
		/// <summary>
		/// Makes the activity start running
		/// </summary>
		public void Play() {
			Debug.Log("Play");
			m_IsPlaying = true;
			m_PlayButton.SetActive(false);
			m_PauseButton.SetActive(true);
			StartCoroutine(UpdatePlaybackTime());
		}
		/// <summary>
		/// Pauses the activity
		/// </summary>
		public void Pause() {
			Debug.Log("Pause");
			m_IsPlaying = false;
			m_PlayButton.SetActive(true);
			m_PauseButton.SetActive(false);
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

		[SerializeField]
		private GameObject m_PlayButton;

		[SerializeField]
		private GameObject m_PauseButton;

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
				AppState.Current = AppState.Current - Profile.ResourceConsumptionSpeed * Time.deltaTime;
				ResourcesDisplay.OnResourceChange();
				yield return null;
			}
		}

		#endregion


	}

}