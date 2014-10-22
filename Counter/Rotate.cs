using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public int angularVelocity = 50;

	Axis axisController;

	void Start() {
		this.axisController = GameObject.FindGameObjectWithTag("GameController").GetComponent<Axis>();
	}

	void Update () {
		Vector2 axis = axisController.AxisRelease;
		Vector2 right = new Vector2 (Mathf.Sin ((this.transform.localRotation.eulerAngles.y + 90) * Mathf.Deg2Rad), Mathf.Cos ((this.transform.localRotation.eulerAngles.y + 90) * Mathf.Deg2Rad));
		Vector2 front = new Vector2 (Mathf.Sin ((this.transform.localRotation.eulerAngles.y) * Mathf.Deg2Rad), Mathf.Cos ((this.transform.localRotation.eulerAngles.y) * Mathf.Deg2Rad));
		float dot = Vector2.Dot (right.normalized, axis.normalized);

		if (dot > 0.2)
			this.transform.Rotate (Vector3.up * angularVelocity * Time.deltaTime * 10);
		else if (dot > 0.01)
			this.transform.Rotate (Vector3.up * angularVelocity * Time.deltaTime);
		else if (dot < -0.2)
			this.transform.Rotate (Vector3.up * angularVelocity * Time.deltaTime * (-1) * 10);
		else if (dot < -0.01)
			this.transform.Rotate (Vector3.up * angularVelocity * Time.deltaTime * (-1));
		else if (Vector2.Dot (front.normalized, axis) < 0)
			this.transform.Rotate (Vector3.up * angularVelocity * Time.deltaTime * 10);
	}
}
