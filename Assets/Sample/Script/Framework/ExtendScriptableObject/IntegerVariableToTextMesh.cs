using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Change the target text content follow value of integer variable
/// </summary>
public class IntegerVariableToTextMesh : MonoBehaviour {
	#region Init, config
	[Header("Ref & Data")]
	[SerializeField] IntegerVariable targetVarable;
	[SerializeField] TMP_Text displayText;
	[SerializeField] string textFormat;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		isFailedConfig = targetVarable == null
			|| displayText == null;
	}

	void OnEnable() {
		if(isFailedConfig)
			return;
		targetVarable.OnValueChangedHandler += OnValueChanged;
	}

	void OnDisable() {
		if(isFailedConfig)
			return;
		targetVarable.OnValueChangedHandler -= OnValueChanged;
	}

	void Start() {
		// first update text
		OnValueChanged();
	}
	#endregion// Init config


	#region Private
	void OnValueChanged() {
		var numberText = targetVarable.Value.ToString();
		displayText.text = string.Format(textFormat, numberText);
	}
	#endregion//Private
}
