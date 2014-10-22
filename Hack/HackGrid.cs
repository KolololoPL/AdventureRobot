using UnityEngine;
using System.Collections;

public class HackGrid : MonoBehaviour {
	public GameObject grid;

	Axis axisController;

	void Start () {
		this.axisController = GameObject.FindGameObjectWithTag("GameController").GetComponent<Axis>();
	}

	void Update () {
		if (!axisController.IsHold) {
			foreach (GameObject hackGrid in GameObject.FindGameObjectsWithTag("HackGrid"))
				Destroy(hackGrid);
			
			return;
		}

		foreach (GameObject hackGrid in GameObject.FindGameObjectsWithTag("HackGrid"))
			if (hackGrid != null)
				return;

		Vector3 position = this.transform.position - (this.transform.up * 1.7f);

		grid.transform.position = position;
		Instantiate(grid);
	}
}
