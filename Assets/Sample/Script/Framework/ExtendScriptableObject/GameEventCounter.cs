using RoboRyanTron.Unite2017.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Listen to game event , and count the number of time this event got raised, and save to variable
/// </summary>
public class GameEventCounter : MonoBehaviour {
	#region Init, config
	[Header("Refs, data")]
	[SerializeField] GameEvent eventToListen;
	[SerializeField] IntegerVariable targetVariable;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		isFailedConfig = eventToListen == null
			|| targetVariable == null;
	}

	void OnEnable() {
		if(isFailedConfig)
			return;
		// reset count first
		targetVariable.Value = 0;
		eventToListen.Subscribe(OnEventRaised);
	}

	void OnDisable() {
		if(isFailedConfig)
			return;
		eventToListen.Unsubscribe(OnEventRaised);
	}
	#endregion// Init config


	#region Private
	void OnEventRaised() {
		targetVariable.Value++;
	}
	#endregion//Private
}
