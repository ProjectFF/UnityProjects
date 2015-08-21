using UnityEngine;
using System.Collections;

public class PlayerHash : MonoBehaviour {

	public int deadHash;
	public int deadBool;
	public int jumpHash;
	public int jumpBool;
	public int runHash;
	public int runBool;
	public int rollHash;
	public int rollBool;
	public int hitHash;
	public int hitBool;

	void Awake(){
	
		deadHash = Animator.StringToHash("BaseLayer.Dying");
		deadBool = Animator.StringToHash ("Dead");
		jumpHash = Animator.StringToHash("BaseLayer.Jumping");
		jumpBool = Animator.StringToHash ("Jump");
		rollHash = Animator.StringToHash("BaseLayer.Rolling");
		rollBool = Animator.StringToHash ("Roll");
		hitHash = Animator.StringToHash("BaseLayer.Hitting");
		hitBool = Animator.StringToHash ("Hit");
		runHash = Animator.StringToHash("BaseLayer.Running");
		runBool = Animator.StringToHash ("Run");
 	}

}
