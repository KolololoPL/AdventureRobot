using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {
	public Transform target;
	public Vector3 delta = new Vector3(-2, 0, -5);
	public float speed = 1;

	void LateUpdate() {
		Vector3 moveTo = target.transform.position + delta;
		MoveTo(moveTo);
	}

	void MoveTo(Vector3 moveTo) {
		Vector3 move;

		if ((moveTo - this.transform.position).magnitude >= speed)
			move = (moveTo - this.transform.position).normalized * speed;
		else
			move = moveTo - this.transform.position;

		this.transform.position += move;
	}

	/*bool standing = false;

	 void LookAt(Vector3 target) {
		Vector3 relPos = target - this.transform.position;
		Quaternion rotation = Quaternion.LookRotation(relPos);
		Quaternion current = this.transform.localRotation;

		if (Mathf.Abs(rotation.eulerAngles.magnitude - current.eulerAngles.magnitude) > 0.5)
			this.transform.localRotation = Quaternion.Slerp(current, rotation, 0.35f);
		else
			this.transform.LookAt(target);
	}

	// Update is called once per frame
	void LateUpdate () {
		switch (mode) {
			case CameraModes.Follow:
				FollowMode();
			break;

			case CameraModes.LookAt:
				LookAtMode();
			break;
		}
	}

	void LookAtMode() {
		this.transform.LookAt (target.transform.position);
	}

	void FollowMode() {
		Vector3 position = new Vector3(X ? target.position.x : this.transform.position.x,
		                               Y ? target.position.y : this.transform.position.y,
		                               Z ? target.position.z : this.transform.position.z);

		Vector3 move = (position + delta) - this.transform.position;
		if (move.magnitude <= 0.5)
			this.transform.position += move;
		else
			this.transform.position += move.normalized * Time.deltaTime * 30;
	}

	public void CalculatePositionDelta() {
		delta = new Vector3 (X ? this.transform.position.x - target.position.x : 0,
		                     Y ? this.transform.position.y - target.position.y : 0,
		                     Z ? this.transform.position.z - target.position.z : 0);
	}

	public bool Standing {
		get {
			return standing;
		}

		set {
			standing = value;
		}
	}

	public Vector3 Position {
		get; set;
	}*/
}
