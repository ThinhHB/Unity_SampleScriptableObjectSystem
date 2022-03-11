using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple rotate the controlTransform to head toward the mousePosition
/// </summary>
public class AimToMousePosition : MonoBehaviour {
	#region Init, config
	[Header("References")]
	[SerializeField] Transform controlTransform;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		// warnings
		Common.Warning(controlTransform != null, this, "Missing controlTransform");
		// mark it as failed config if missing any references
		isFailedConfig = controlTransform == null;
	}

	void OnEnable() {
		if(isFailedConfig) {
			enabled = false;
		}
	}
	#endregion//init, config


	#region Private
	///<summary> DO NOT call Camera.main in Update, it's FingObject func which heavy, better cache it </summary>
	Camera _cacheMainCamera;
	void Update() {
		// check cache camera
		if(_cacheMainCamera == null) {
			_cacheMainCamera = Camera.main;
		}
		// aimming
		var mousePos = _cacheMainCamera.ScreenToWorldPoint(Input.mousePosition);
		//make it same z coor with gunTrans, use to calculate the direction
		mousePos.z = controlTransform.position.z;
		var direction = mousePos - controlTransform.position;
		controlTransform.up = direction;
	}
	#endregion//Private
}
