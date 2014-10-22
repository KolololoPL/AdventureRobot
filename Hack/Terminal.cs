using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {
	public Events events;
	public GameObject hackTag;

	public void Use() {
		EventManager.Call(events, this.gameObject);
	}
}
