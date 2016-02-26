using UnityEngine;
using System.Collections;

public class MovingObjectBehaviour : MonoBehaviour {


    //No Rigidbody
    //Mock up with transform on Fixed update
    //or Update with *Time.DeltaTime	

    public float Speed = 1;
    
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z -= Speed * Time.deltaTime;

        transform.position = pos;

        if(pos.z < -10)
        {
            //Out of sight,
            //Returning to Pool
            //Debug.Log("Out of sight, Returning to Pool");

            ReturnObject();
        }

    }
	
	public void ReturnObject()
    {

        PoolManager.Instance.ReturnObject(this.gameObject);

    }


}
