using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {


	private TouchManager _instance;

	public TouchManager Instance
    {

		get
		{ 
			if (_instance == null) {
				Debug.Log ("There is no touch manager, making a new one.");
				_instance = new TouchManager ();
			}

			return _instance;
		}

	}


    public bool Touching = false;
    //check all touches and if got a move send it to player!

    void Update()
    {
        if (Touching == false )
        {
            

        }

    }

    


}
