using UnityEngine;
using System.Collections;

public class EventManagerV2 : Singleton<EventManagerV2> {

    public delegate void Custom_Event();
    public event Custom_Event Custom_Event_Methods;

    public void TriggerEvent()
    {
        Custom_Event_Methods();

    }


}
