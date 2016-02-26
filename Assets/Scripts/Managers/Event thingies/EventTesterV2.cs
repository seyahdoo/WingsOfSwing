using UnityEngine;
using System.Collections;

public class EventTesterV2 : MonoBehaviour {

	void Start()
    {

        EventManagerV2.Instance.Custom_Event_Methods += ToBeTriggered;
        StartCoroutine(TriggerMadness());
    }

    void ToBeTriggered()
    {

        Debug.Log("I triggered");
    }

    IEnumerator TriggerMadness()
    {
        while(true)
        {
            EventManagerV2.Instance.TriggerEvent();

            yield return new WaitForSeconds(3.0f);
        }
    }


}
