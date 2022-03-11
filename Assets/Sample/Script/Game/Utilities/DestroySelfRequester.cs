using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Invoke the In_DestroySelf() function to let it destroy self gameobject
/// </summary>
public class DestroySelfRequester : MonoBehaviour {
	public void In_DestroySelf() {
		Destroy(gameObject);
	}
}
