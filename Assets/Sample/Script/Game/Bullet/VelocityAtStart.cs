using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Simple config velocity at Start()
/// </summary>
public class VelocityAtStart : MonoBehaviour {
	#region Init, config
	[Header("Reference")]
	[SerializeField] Rigidbody2D controlRigidbody;

	[Header("Config")]
	[SerializeField] Vector2 randomVelocityRange;
	[SerializeField] Direction direction;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		Common.Warning(controlRigidbody != null, this, "Missing controlRigidbody");
		isFailedConfig = controlRigidbody == null;
	}

	void Start() {
		if(isFailedConfig) {
			return;
		}
		var direction = GetDirectionVectorBaseOnConfig();
		var velo = direction * Random.Range(randomVelocityRange.x, randomVelocityRange.y);
		controlRigidbody.velocity = velo;
	}

	Vector3 GetDirectionVectorBaseOnConfig() {
		switch(direction) {
		case Direction.Forward:
			return transform.forward;
		case Direction.Up:
			return transform.up;
		case Direction.Right:
			return transform.right;
		default:
			return transform.right;
		}
	}
	#endregion//init, config


	#region Class
	public enum Direction {
		Up, Forward, Right
	}
	#endregion//Class
}
