using UnityEngine;
using System.Collections;

public class EventTester : MonoBehaviour {


	void Start () {

        EventManager.SampleEvent += Logs;
        StartCoroutine(Triggerer());

        

    }
	
    void Logs()
    {
        Debug.Log("I Log!");

    }

	IEnumerator Triggerer()
    {

        while (true)
        {
            EventManager.SampleEventTrigger();
            yield return new WaitForSeconds(1.0f);
        }
    }

}
