using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject sample;
	public GameObject terminal;

	void OnEnable () {
		EventManager.OnSpawnEvent += Spawn;
	}

	void OnDisable () {
		EventManager.OnSpawnEvent -= Spawn;
	}
	
	void Spawn(GameObject caller) {
		if (!caller.Equals(terminal))
			return;

		Instantiate(sample, this.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
	}
}
