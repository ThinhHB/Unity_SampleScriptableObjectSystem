using UnityEngine;
using System.Collections;
using UnityEngine.Events;

/// <summary>
/// Auto destroy. Attach to an object, config lifeTime.
/// After object spawned, It'll auto destroy when lifeTime is out
/// </summary>
public class AutoDestroy : MonoBehaviour {
	[Header("Config life time")]
	[Range(0, 10f)] [SerializeField] float lifeTime = 1f;

	[Header("Events")]
	[SerializeField] UnityEvent OnTimeUpAndDestroyHandler;

	// fields
	float _count;

	// Use this for initialization
	void Start() {
		_count = lifeTime;
	}

	// Update is called once per frame
	void Update() {
		_count -= Time.deltaTime;
		if(_count <= 0) {
			Destroy(gameObject);
			OnTimeUpAndDestroyHandler.Invoke();
		}
	}
}
