using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
	public float velocity = 25, jumpStrength = 20;

	//Hashes
	int speedHash = Animator.StringToHash ("Speed");
	int jumpHash = Animator.StringToHash ("Jump");
	int idleStateHash = Animator.StringToHash ("Base Layer.Idle");

	//Other
	Animator anim;
	Gravity gravity;
	Axis axisController;

	void Start() {
		this.anim = this.GetComponent<Animator> ();
		this.gravity = this.GetComponent<Gravity> ();
		this.axisController = GameObject.FindGameObjectWithTag("GameController").GetComponent<Axis>();
	}

	void FixedUpdate () {
		//Move
		Vector2 axis = axisController.AxisRelease;
		float magnitude = 0;

		if (axis.magnitude > 0)
			if (axis.magnitude > 0.7f && this.anim.GetCurrentAnimatorStateInfo(0).nameHash != idleStateHash)
				magnitude = 1.7f;
			else
				magnitude = 0.5f;
		else
			magnitude = 0;

		this.rigidbody.AddForce((Vector3.forward * axis.normalized.y + Vector3.right * axis.normalized.x) * magnitude * velocity * Time.deltaTime, ForceMode.VelocityChange);
		this.anim.SetFloat (speedHash, magnitude);
	}

	void Update() {
		//Jump
		if (Input.GetButtonUp ("Action") && gravity.IsDown && this.anim.GetCurrentAnimatorStateInfo(0).nameHash != idleStateHash)
			this.anim.SetBool(jumpHash, true);
	}

	void OnJumpEvent() {
		Vector3 forward = new Vector3 (this.rigidbody.velocity.x, 0, this.rigidbody.velocity.z);
		this.rigidbody.AddForce(this.transform.up * jumpStrength + forward * 1.75f, ForceMode.VelocityChange);
		gravity.IsDown = false;
	}
}
