using UnityEngine;
using System.Collections;

public class yep : MonoBehaviour {


    //TODO Write some elegant stuff here.

    public GameObject o;

    void OnEnable()
    {
        GameObject go = Instantiate(o);
        go.name = "Duplicated";
    }
	
	
	
	
}
