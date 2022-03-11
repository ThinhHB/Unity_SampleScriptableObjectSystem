using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follow the ScriptableObect system, like FloatVariable, but this one is for Integer
/// </summary>
[CreateAssetMenu]
public class IntegerVariable : ScriptableObject {
	[TextArea(2, 10)] public string DeveloperDescription = "";
	///<summary> Raised when new value was set to this var </summary>
	public event Action OnValueChangedHandler;

	[SerializeField] int value;
	public int Value {
		get {
			return value;
		}
		set {
			this.value = value;
			OnValueChangedHandler?.Invoke();
		}
	}
}
