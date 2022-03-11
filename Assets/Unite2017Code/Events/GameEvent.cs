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
		/// <summary>
		/// The list of listeners that this event will notify if it is raised.
		/// </summary>
		private readonly List<GameEventListener> eventListeners =
			new List<GameEventListener>();

		public void Raise() {
			for(int i = eventListeners.Count - 1; i >= 0; i--)
				eventListeners[i].OnEventRaised();
			//extend for normal listener (not GameEventListener)
			if(_listeners != null)
				_listeners.Invoke();
		}

		public void RegisterListener(GameEventListener listener) {
			if(!eventListeners.Contains(listener))
				eventListeners.Add(listener);
		}

		public void UnregisterListener(GameEventListener listener) {
			if(eventListeners.Contains(listener))
				eventListeners.Remove(listener);
		}


		//=======================
		//========= extend for the normal listen
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