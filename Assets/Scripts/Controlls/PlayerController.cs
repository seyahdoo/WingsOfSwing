using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform[] PlacesToBe;

    private SmoothFollow _smoothFollow;

    public float Return_Time = 1.0f;

    void Awake()
    {
        _smoothFollow = GetComponent<SmoothFollow>();
        if (_smoothFollow == null)
        {
            Debug.LogWarning("Player needs to have"+
                "SmoothFollow to go line to line,"+
                "Please add Smooth Follow to Player object."+
                "Fixing for now.");
            _smoothFollow = this.gameObject.AddComponent<SmoothFollow>();
            _smoothFollow.TargetTransform = PlacesToBe[1];
            _smoothFollow.MyTransform = this.transform;

        }

        TouchManager.Instance.playerController = this;
            
    }


	public void Go(TouchManager.Direction direction)
	{
        Debug.Log("I'm Going " + direction);


        StopCoroutine("GoEnum");

        StartCoroutine("GoEnum",direction);

	}
    
    IEnumerator GoEnum (TouchManager.Direction direction)
    {

        _smoothFollow.TargetTransform = PlacesToBe[(int)direction];

        yield return new WaitForSeconds(Return_Time);

        Debug.Log("returning");
        _smoothFollow.TargetTransform = PlacesToBe[0];

        yield break;
    }




}
