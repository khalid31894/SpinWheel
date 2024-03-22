using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();


    public void Raise()
    {
        for (int i = listeners.Count; i >= 0; i--)
        {
            listeners[0].OnEventRaised();


        }
    }

    public void RegisterListener(GameEventListener listener) { listeners.Add(listener); }
    public void UnregisterListener(GameEventListener listener) { listeners.Remove(listener); }

}