using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialSubject : MonoBehaviour
{
    private List<ITutorialObserver> _observers = new List<ITutorialObserver>();

    public void AddTutorialObserver(ITutorialObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(ITutorialObserver observer)
    {
        _observers.Remove(observer);
    }

    protected void NotifyTutorialObservers(string actionName)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(actionName);
        });
    }
}
