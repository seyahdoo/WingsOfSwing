using UnityEngine;
using System.Collections;

public class EnableTester : MonoBehaviour {
	
	
	void OnEnable()
    {
        Debug.Log("Enabled " + this.name);
    }
	
    void OnDisable()
    {
        Debug.Log("Disabled " + this.name);
    }
	
    void Awake()
    {
        Debug.Log("Awake " + this.name); 
    }
	
    void Start()
    {
        Debug.Log("Start " + this.name);
    }

}
