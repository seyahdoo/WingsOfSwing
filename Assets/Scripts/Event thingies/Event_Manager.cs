using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Event_Manager : Singleton<Event_Manager> {

    //tobe private
    public List<Custom_Event> Events = new List<Custom_Event>();

    public class Custom_Event
    {
        public string Event_Name;
        public Event Event;
        public delegate void EventDelegate();
    }
    
    void AddEvent(string EventName)
    {

        Custom_Event ToAdd = new Custom_Event();
        ToAdd.Event_Name = EventName;

    }
    
    void TriggerEvent(string EventName) {

        foreach (var item in Events)
        {
            if( item.Event_Name == EventName)
            {
                
            }
        }

    }

    //Event GetEvent(string EventName) { }


    //todo research getting function as parameter
    //void SubscribeToEvent()


}
