using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary> Config the prefab, and invoke the In_SpawnObject() and it will spawn object at current position </summary>
public class SpawnObjectRequester : MonoBehaviour {
	#region Init, config
	[Header("Config")]
	[SerializeField] GameObject prefab;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		isFailedConfig = prefab == null;
	}
	#endregion//init, config

	#region Public
	public void In_SpawnObject() {
		if(isFailedConfig) {
			Common.Warning(false, this, "Missing prefab!!");
			return;
		}
		var instance = Instantiate(prefab).transform;
		instance.position = transform.position;
	}
	#endregion//Public
}
