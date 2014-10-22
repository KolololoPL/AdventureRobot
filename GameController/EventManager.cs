using UnityEngine;
using System.Collections;

public enum Events {DieEvent = 1 << 0, LiftEvent = 1 << 1, SpawnEvent = 1 << 2};

public static class EventManager {
	public delegate void DieEvent(GameObject gameObject);
	public static event DieEvent OnDieEvent;

	public delegate void LiftEvent(GameObject gameObject);
	public static event LiftEvent OnLiftEvent;

	public delegate void SpawnEvent(GameObject gameObject);
	public static event SpawnEvent OnSpawnEvent;

	public static void Call(Events eventType, GameObject caller) {
		if (eventType == Events.DieEvent) {
			if (OnDieEvent != null)
				OnDieEvent(caller);
		} else if (eventType == Events.LiftEvent) {
			if (OnLiftEvent != null)
				OnLiftEvent(caller);
		} else if (eventType == Events.SpawnEvent) {
			if (OnSpawnEvent != null)
				OnSpawnEvent(caller);
		}
	}
}
