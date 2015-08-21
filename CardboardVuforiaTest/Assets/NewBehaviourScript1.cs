using UnityEngine;
using System.Collections;
using Vuforia;

public class NewBehaviourScript1 : MonoBehaviour, ITrackableEventHandler 
{

		private TrackableBehaviour mTrackableBehaviour;
		
		void Start()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();

			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
		}
		
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
			{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
			    newStatus == TrackableBehaviour.Status.TRACKED ||
			    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				// Play audio when target is found
				GetComponent<AudioSource>().Play();
				GetComponent<Animation>().Play();
			
			}
			else
			{
				GetComponent<Animation>().Stop();
				GetComponent<AudioSource>().Stop();
			}	
		}   
}