using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Continue spawn object with configurable interval, same spawn position at this spawner, but random Y coordinate
/// </summary>
public class SpawnObjectWithInterval : MonoBehaviour {
	#region Init, config
	[Header("Config")]
	[SerializeField] GameObject prefab;
	[SerializeField] Vector2 randomIntervalRange;
	[SerializeField] float randomYRange;

	[Header("ShareData")]
	[SerializeField] IntegerVariable counterVaraible;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		Common.Warning(prefab != null, this, "Missing prefab");
		isFailedConfig = prefab == null
			|| counterVaraible == null;
	}

	void OnEnable() {
		if(isFailedConfig) {
			// disable Update function
			enabled = false;
		}
		// reset counter
		counterVaraible.Value = 0;
	}
	#endregion//init, config


	#region Private
	float _timer = 0f;
	void Update() {
		// check timer, reach zero, then reset timer and spawn object
		_timer -= Time.deltaTime;
		if(_timer <= 0f) {
			_timer = Random.Range(randomIntervalRange.x, randomIntervalRange.y);
			SpawnObject();
		}
	}

	void SpawnObject() {
		var instance = Instantiate(prefab) as GameObject;
		var spawnPos = transform.position;
		spawnPos.y += Random.Range(-randomYRange, randomYRange);
		instance.transform.position = spawnPos;
		// increase counter
		counterVaraible.Value++;
	}
	#endregion//Private
}
