using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {
	Transform target;

	void Start() {
		this.target = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}

	void Update () {
		this.transform.LookAt(target);
		this.transform.Rotate(new Vector3(90, 0, 0));
	}
}
