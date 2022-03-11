using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The "HealthBar", attach to object that can be damaged by other attacker. The GiveDamageOnCollision will search for this component on Collision, then reduce the HP. Use the OnOutOfHP event to call other action when HP down to zero
/// </summary>
public class Damageable : MonoBehaviour {
	[Header("Config")]
	[SerializeField] int baseHealth;

	[Header("Expose current HP")]
	[SerializeField] int currentHP;

	[Header("Events")]
	[SerializeField] UnityEvent OnOutOfHpHandler;

	void OnEnable() {
		currentHP = baseHealth;
	}

	///<summary> Attacker will call this function </summary>
	public void TakeDamage(int damage) {
		currentHP -= damage;
		if(currentHP <= 0) {
			OnOutOfHpHandler.Invoke();
		}
	}
}
