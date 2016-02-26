using UnityEngine;
using System.Collections;


public class Tester : MonoBehaviour {


    public Tester()
    {

        ToBePooled = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    public GameObject ToBePooled;

    void Awake()
    {

        //Presential?! object tests
        //Debug.Log(TouchManager.Instance.name);
        //TouchManager.Instance.name = "asdsadasd";
        //Debug.Log(TouchManager.Instance.name);

        //Tester[] t = new Tester[0];
        //t[0] = GameObject.Instantiate<Tester>(GameObject.CreatePrimitive(PrimitiveType.Cube));
        //t[1] = new Tester();
        //Pool<Tester>.ObjectsInPool = t;
        //Pool<Tester>.One.name = "asdasdsa";

        


    }

	public void LogSomething(string Text)
	{
		Debug.Log (Text);
	}

}
