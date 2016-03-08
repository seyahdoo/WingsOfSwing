using UnityEngine;
using System.Collections;

public class PoolTester : MonoBehaviour {


    //TODO Write some elegant stuff here.

    public Pool Pool;

	void Start()
    {
        Pool = GameObject.FindGameObjectWithTag("CubePool").GetComponent<Pool>();

        Pool.InstantiatePool(10);

        //get from pool
        //GameObject FromPool = Pool.GetFromPool();

        //Give Random Rotation

        //Give Random Transform

        //Give Random Force Torque

        //Add GameObject OnEnable
        ///Pool Itself -in 5 seconds






    }
	
	
	
	
}
