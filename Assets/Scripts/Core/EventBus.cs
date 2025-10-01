using System;
using System.Collections.Generic;

public class EventBus
{
    private readonly Dictionary<Type, object> _subscribers = new();

    public void Subscribe<T>(Action<T> handler)
    {
        if (!_subscribers.TryGetValue(typeof(T), out var listObj))
        {
            listObj = new List<Action<T>>();
            _subscribers[typeof(T)] = listObj;
        }

        var list = (List<Action<T>>)listObj;
        list.Add(handler);
    }

    public void Unsubscribe<T>(Action<T> handler)
    {
        if (_subscribers.TryGetValue(typeof(T), out var listObj))
        {
            var list = (List<Action<T>>)listObj;
            list.Remove(handler);
            if (list.Count == 0)
            {
                _subscribers.Remove(typeof(T));
            }
        }
    }

    public void Publish<T>(T evt)
    {
        if (_subscribers.TryGetValue(typeof(T), out var listObj))
        {
            var list = (List<Action<T>>)listObj;
            for (var i = list.Count - 1; i >= 0; i--)
            {
                try
                {
                    list[i](evt);
                }
                catch (Exception ex)
                {
                    UnityEngine.Debug.LogError($"[EventBus] Exception in handler {list[i]?.Method.Name}: {ex}");
                }
            }
        }
    }
}