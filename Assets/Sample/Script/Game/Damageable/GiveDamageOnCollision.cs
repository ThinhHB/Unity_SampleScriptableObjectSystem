using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Attach it to the "attacker" objects, has Rigidbody and Collider2D, on collision occur, it search for the Damageable component on "other" object, and reduce damage on it. use the OnGiveDamage event to do other behavior (spawn fx ..)
/// </summary>
public class GiveDamageOnCollision : MonoBehaviour {
	[Header("Config")]
	[SerializeField] int damage;

	[Header("Events")]
	[SerializeField] UnityEvent OnSuccessGiveDamageHandler;

	void OnCollisionEnter2D(Collision2D collision) {
		// search for Damageable component, then reduce HP
		var hp = collision.collider.GetComponent<Damageable>();
		if(hp != null) {
			hp.TakeDamage(damage);
			OnSuccessGiveDamageHandler.Invoke();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// search for Damageable component, then reduce HP
		var hp = collider.GetComponent<Damageable>();
		if(hp != null) {
			hp.TakeDamage(damage);
			OnSuccessGiveDamageHandler.Invoke();
		}
	}
}
