using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour {
	public Events events;

	int entrances = 0;
	bool isPressed = false;
	Vector3 moveTo;

	void Start() {
		moveTo = this.transform.position;
	}

	void Update() {
		//Move
		Vector3 move = (moveTo - this.transform.position).normalized * Time.deltaTime;
		if ((moveTo - this.transform.position).magnitude < move.magnitude)
			move = moveTo - this.transform.position;

		this.transform.position += move;

		//Press
		if ((entrances > 0 && isPressed == false) || (entrances <= 0 && isPressed == true))
			Switch();
	}

	void Switch() {
		if (isPressed) {
			moveTo += Vector3.up * 0.2f;//0.195f;
			isPressed = false;
		} else {
			moveTo -= Vector3.up * 0.2f;//0.195f;
			isPressed = true;
		}

		EventManager.Call(events, this.gameObject);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player") || other.CompareTag("WeightObject"))
			entrances++;
	}

	void OnTriggerExit(Collider other) {
		if ((other.CompareTag("Player") || other.CompareTag("WeightObject")) && entrances > 0)
			entrances--;
	}
}
