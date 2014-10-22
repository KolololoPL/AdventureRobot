using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		EventManager.Call(Events.DieEvent, other.gameObject);
	}
}
