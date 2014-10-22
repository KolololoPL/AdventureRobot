using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	public Animator anim;
	public GameObject killFlash;

	int onHash = Animator.StringToHash("On");

	//for respawn
	float cooldown = 0.5f;
	void Update () {
		if (cooldown > 0)
			cooldown -= Time.deltaTime;
	}	

	void Respawn(GameObject caller) {
		if (cooldown > 0 || !caller.CompareTag("Player"))
			return;

		if (killFlash != null) {
			killFlash.transform.position = caller.transform.position;
			Instantiate(killFlash);
		}

		Vector3 move = new Vector3(this.transform.position.x, this.transform.position.y + 53, this.transform.position.z);
		caller.transform.position = move;

		cooldown = 0.5f;
	}

	void OnCollisionEnter(Collision col) {
		if (!IsActive)
			Activate();
	}

	void Activate () {
		//Off all spawn points
		foreach (GameObject spawn in GameObject.FindGameObjectsWithTag("SpawnPoint"))
			if(spawn.GetComponent<SpawnController>() != null)
				if (spawn.GetComponent<SpawnController>().IsActive)
					spawn.GetComponent<SpawnController>().Switch();

		//On this spawn point
		Switch();
	}

	void Switch() {
		if (anim.GetBool (onHash)){
			anim.SetBool (onHash, false);
			EventManager.OnDieEvent -= this.Respawn;
		} else{
			anim.SetBool (onHash, true);
			EventManager.OnDieEvent += this.Respawn;
		}
	}

	public bool IsActive {
		get {
			return anim.GetBool (onHash);
		}
	}
}
