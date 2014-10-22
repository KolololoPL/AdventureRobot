using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hack : MonoBehaviour {
	Axis axisController;
	GameObject target;

	Dictionary<GameObject, GameObject> terminals = new Dictionary<GameObject, GameObject>();

	void Start() {
		axisController = GameObject.FindGameObjectWithTag("GameController").GetComponent<Axis>();
	}

	void Update() {
		//Hacking chosen terminal if button released
		HackTerminal();

		//Looks for target
		Aim();

		//Controls tags size
		Sizing();
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("HackAble")) {
			this.terminals.Add(other.gameObject, Instantiate(other.GetComponent<Terminal>().hackTag, other.transform.position + Vector3.up * 3.25f, new Quaternion()) as GameObject);
		}
	}

	void OnDestroy() {
		foreach(GameObject tag in terminals.Values)
			Destroy(tag);
	}

	void HackTerminal() {
		//Using chosen terminal
		if (target != null && !axisController.IsHold)
			target.GetComponent<Terminal>().Use();
	}

	void Aim() {
		target = null;
		if (!axisController.AxisHold.Equals(new Vector2())) {
			float min = 100;
			foreach(GameObject terminal in terminals.Keys){
				Vector3 axis;
				//Just estetic use
				if (this.axisController.AxisHold.magnitude >= 0.75f)
					axis = new Vector3(this.axisController.AxisHold.x, 0, this.axisController.AxisHold.y);
				else
					return;
				//--

				float distance = Vector3.Distance(terminal.transform.position, this.transform.position + axis * 5);
				if(distance < min) {
					target = terminal;
					min = distance;
				}
			}	
		}
	}

	void Sizing() {
		foreach (GameObject tag in terminals.Values)
			tag.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

		GameObject targetTag;
		if (target != null && terminals.TryGetValue(target, out targetTag))
			targetTag.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
	}
}