// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoboRyanTron.Unite2017.Events {
	[CreateAssetMenu]
	public class GameEvent : ScriptableObject {
		[TextArea(2, 10)] public string DeveloperDescription = "";

		event Action _listeners;

		public void Subscribe(Action callback) {
			//if(_listeners != null)
			_listeners += callback;
		}

		public void Unsubscribe(Action callback) {
			if(_listeners != null)
				_listeners -= callback;
		}

		void OnDisable() {
			// clear all references
			_listeners = null;
		}
	}
}