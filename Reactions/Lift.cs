using UnityEngine;
using System.Collections;

public class Lift : MonoBehaviour {
	public Vector3 rail;
	public float speed = 0.1f;
	public GameObject terminal;

	Vector3 moveTo, move, zeroPosition;
	bool isUp = true;

	void OnEnable() {
		EventManager.OnLiftEvent += Run;
	}

	void Start () {
		moveTo = this.transform.position;
		zeroPosition = this.transform.position;
	}

	void OnDisable() {
		EventManager.OnLiftEvent -= Run;
	}

	void FixedUpdate () {
		/*float relativeSpeed = speed * Time.deltaTime;
		if ((moveTo - this.transform.position).magnitude >= relativeSpeed)
			move = (moveTo - this.transform.position).normalized * relativeSpeed;
		else
			move = moveTo - this.transform.position;*/
		if ((moveTo - this.transform.position).magnitude >= speed)
			move = (moveTo - this.transform.position).normalized * speed;
		else
			move = moveTo - this.transform.position;

		this.transform.position += move;
	}

	void Run (GameObject caller) {
		if (!terminal.Equals(caller))
			return;

		if (isUp){
			moveTo = zeroPosition + rail;
			isUp = false;
		} else {
			moveTo = zeroPosition;
			isUp = true;
		}
	}
}
