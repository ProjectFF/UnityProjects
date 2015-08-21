using UnityEngine;
using System.Collections;
using Vuforia;

public class anim : MonoBehaviour, ITrackableEventHandler{

	private TrackableBehaviour mTrackableBehaviour;
	Animator animator_;
	int action = Animator.StringToHash("Action");

	void Start()
	{
		animator_ = GetComponent<Animator> ();
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

		Collider[] colliderComponents = GetComponentsInChildren<Collider>();
		
		// *** Additional animation code
		Animation[] animationComponents = GetComponentsInChildren<Animation>();

		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			animator_.SetTrigger(action);
			GetComponent<Animation>().Play();
		}
		else
		{
			GetComponent<Animation>().Stop();
		}
	}   
}