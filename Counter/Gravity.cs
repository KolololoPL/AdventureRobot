using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public float gravity = 9.81f, miscount = 0.02f, height = 1f;

	//Jump part
	int jumpHash = Animator.StringToHash ("Jump");
	Animator anim;
	
	bool isDown = true;

	void Start() {
		this.anim = this.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		Ray middle = new Ray (this.transform.position, -this.transform.up);
		RaycastHit hitM;

		Physics.Raycast (middle, out hitM);
		
		if (hitM.distance - height > miscount) {
			this.rigidbody.AddForce (-this.transform.up * gravity * (Mathf.Abs(hitM.distance - height) > miscount * 5 ? 12 : 1), ForceMode.Acceleration);
			this.IsDown = false;
		}

		CheckIfDown(hitM);
	}

	void CheckIfDown(RaycastHit hitM) {
		if (hitM.distance - height <= miscount)
			IsDown = true;
	}

	void OnCollisionEnter (Collision col) {
		//Jump part
		anim.SetBool(jumpHash, false);
	}

	public bool IsDown {
		get {
			return isDown;
		}
		
		set {
			isDown = value;
		}
	}
}
