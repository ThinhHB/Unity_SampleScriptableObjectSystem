using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to object that has rigibody, config the moving key and speed, it will moving rigidbody when user press selected keys
/// </summary>
public class MovingByKeyboard : MonoBehaviour {
	#region Init, config
	[Header("References")]
	[SerializeField] Rigidbody2D controlRigid;

	[Header("Config")]
	[SerializeField] float maxSpeed = 2f;
	[SerializeField] float acceleration = 5f;
	[SerializeField] KeyCode moveLeftKey;
	[SerializeField] KeyCode moveRightKey;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		// warnings
		Common.Warning(controlRigid != null, this, "Missing controlRigidbody");
		// mark it as failed config if missing any references
		isFailedConfig = controlRigid == null;
	}

	void OnEnable() {
		// missing or failed any config? then disable this component
		if(isFailedConfig) {
			enabled = false;
		}
	}
	#endregion//init, config


	#region Private
	void Update() {
		// calculate raw input base on key hold
		var rawInput = (Input.GetKey(moveLeftKey) ? -1f : 0f) + (Input.GetKey(moveRightKey) ? 1f : 0f);
		// modify velocity. Check reaching maxSpeed
		var velo = controlRigid.velocity;
		if(Mathf.Abs(velo.x) > maxSpeed) {
			velo.x = Mathf.Clamp(velo.x, -maxSpeed, maxSpeed);
			controlRigid.velocity = velo;
			return;
		}
		velo.x += acceleration * rawInput * Time.deltaTime;
		controlRigid.velocity = velo;
	}
	#endregion//Private
}
