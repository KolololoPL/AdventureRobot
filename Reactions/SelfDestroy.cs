using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {
	public float timer;

	float time = 0;

	void Update () {
		if (time >= timer)
			Destroy(this.gameObject);

		time += Time.deltaTime;
	}
}
