using UnityEngine;
using System.Collections;

public class WeightBehaviours : MonoBehaviour {
	public GameObject killFlash;

	void OnEnable() {
		EventManager.OnDieEvent += KillMe;
	}

	void OnDisable() {
		EventManager.OnDieEvent -= KillMe;
	}

	void KillMe(GameObject caller) {
		if (!caller.CompareTag("WeightObject"))
			return;

		if (killFlash != null) {
			killFlash.transform.position = caller.transform.position;
			Instantiate(killFlash);
		}

		Destroy(caller);
	}
}