using UnityEngine;
using System.Collections;

public class Axis : MonoBehaviour {
	public float delay = 1.5f;
	public Animator playerAnim;

	int idleStateHash = Animator.StringToHash ("Base Layer.Idle");
	float time;
	bool isHold = false;
	Vector2 axis;

	void Update () {
		axis = new Vector2(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

		//Hold
		if (Input.GetButton("Action"))
			time += Time.deltaTime;
		else
			time = 0;

		if (time >= delay && this.playerAnim.GetCurrentAnimatorStateInfo(0).nameHash == idleStateHash)
			isHold = true;
		else
			isHold = false;
	}

	public Vector2 AxisRelease {
		get {
			if (!isHold)
				return axis;
			else
				return new Vector2(0 ,0);
		}
	}

	public Vector2 AxisHold {
		get {
			if (isHold)
				return axis;
			else
				return new Vector2(0 ,0);
		}
	}

	public bool IsHold {
		get {
			return isHold;
		}
	}
}
