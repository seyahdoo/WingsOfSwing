using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SmoothFollow))]
public class LeftRightSwipe : MonoBehaviour {


    //TODO Write some elegant stuff here.

    //Object tree
    //EnemyRoot(SpawnedObjectBehaviour)
    /////EnemyMesh(Smooth Follow,LeftRightSwipe)
    ////////EnemyColliders
    /////Left Transform
    /////Right Transform

    public Transform LeftT;
    public Transform RightT;
    public SmoothFollow Follower;
    public float Speed;

    public float LeftToRightTime = 1.0f;

    void OnEnable()
    {
        if(Follower == null)
            Follower = GetComponent<SmoothFollow>();

        Follower.MyTransform = this.transform;
        Follower.TargetTransform = RightT;
        StartCoroutine("GoLeftRight");


    }

    void OnDisable()
    {
        StopCoroutine("GoLeftRight");
    }	

	IEnumerator GoLeftRight()
    {

        //Debug.Log("Going LeftRight");
        Follower.SpeedPosition = Speed;
        Follower.SpeedRotation = Speed;

        while(true)
        {
            Follower.TargetTransform = RightT;
            yield return new WaitForSeconds(LeftToRightTime);

            Follower.TargetTransform = LeftT;
            yield return new WaitForSeconds(LeftToRightTime);
        }

    }







	
	
	
}
