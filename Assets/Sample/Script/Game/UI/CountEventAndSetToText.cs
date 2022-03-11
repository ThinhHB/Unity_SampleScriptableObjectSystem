using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Config the eventID, it will count how many time that event get raised, then config to the target text
/// </summary>
public class CountEventAndSetToText : MonoBehaviour {
	#region Init, config
	[Header("Reference")]
	[SerializeField] TMP_Text displayText;

	[Header("Config")]
	//[SerializeField] EventID eventID;
	[SerializeField] string textFormat;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		Common.Warning(displayText != null, this, "Missing DisplayText");
		isFailedConfig = displayText == null;
	}

	void OnEnable() {
		if(isFailedConfig)
			return;
		_count = 0;
		//this.RegisterListener(eventID, OnEventRaise);
	}

	void OnDisable() {
		if(isFailedConfig)
			return;
		//if(EventDispatcher.HasInstance()) {
		//	EventDispatcher.Instance.RemoveListener(eventID, OnEventRaise);
		//}
	}
	#endregion//init, config


	#region Private
	int _count;

	void OnEventRaise(object para) {
		_count++;
		displayText.text = string.Format(textFormat, _count.ToString());
	}
	#endregion//Private
}
