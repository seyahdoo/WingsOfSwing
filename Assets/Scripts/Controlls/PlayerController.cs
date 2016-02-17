using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SmoothFollow))]
public class PlayerController : MonoBehaviour {


    public Transform[] PlacesToBe;
    private SmoothFollow _smoothFollow;

    public float Return_Time = 1.0f;
    
    public bool Going;
    public TouchManager.Direction GoDirection;

    public int ChargeCount;
    public TouchManager.Direction ChargeDirection;

    public bool Comboing;
    public TouchManager.Direction ComboDirection = TouchManager.Direction.Nowhere;

    public bool Immobilized;
    
    void Awake()
    {
        _smoothFollow = GetComponent<SmoothFollow>();
        //if (_smoothFollow == null)
        //{
        //    Debug.LogWarning("Player needs to have"+
        //        "SmoothFollow to go line to line,"+
        //        "Please add Smooth Follow to Player object."+
        //        "Fixing for now.");
        //    _smoothFollow = this.gameObject.AddComponent<SmoothFollow>();
        //    _smoothFollow.TargetTransform = PlacesToBe[1];
        //    _smoothFollow.MyTransform = this.transform;
        //}

        TouchManager.Instance.playerController = this;

        EventManager.GameOverEvent += Stop;
        EventManager.GameStartEvent += Start;

    }

    void Update()
    {

        //set animator thingies
    }

	public void Swipe(TouchManager.Direction SwipeDirection)
	{
        //Debug.Log("Player Knows Human Swiped: " + SwipeDirection);
        
        HandleCharge(SwipeDirection);

        HandleGo(SwipeDirection);

	}
    
    void HandleGo(TouchManager.Direction SwipeDirection)
    {
        if (Immobilized) return;

        StopGo();

        StartCoroutine("Go", SwipeDirection);

    }
    IEnumerator Go (TouchManager.Direction Direction)
    {
        Going = true;
        GoDirection = Direction;

        _smoothFollow.TargetTransform = PlacesToBe[(int)Direction];


        yield return new WaitForSeconds(Return_Time);

        Going = false;
        GoDirection = TouchManager.Direction.Nowhere;

        ReturnLane();

        yield break;
    }
    void StopGo()
    {
        Going = false;
        StopCoroutine("Go");
    }
    void ReturnLane()
    {
       // Debug.Log("returning");
        _smoothFollow.TargetTransform = PlacesToBe[0];
        ChargeCount = 0;
        ChargeDirection = TouchManager.Direction.Nowhere;
    }
 
    void HandleCharge(TouchManager.Direction SwipeDirection)
    {
        //HandleCharging,Combo
        if (ChargeCount >= 0)
        {
            if (SwipeDirection == ChargeDirection)
                ChargeCount++;

            if (SwipeDirection != ChargeDirection)
            {
                if(ChargeCount >= 1)
                {
                    StartCoroutine(Combo(SwipeDirection,ChargeCount));
                    ChargeDirection = TouchManager.Direction.Nowhere;
                }
                else
                {
                    ChargeCount = 0;
                    ChargeDirection = SwipeDirection;
                }

            }
        }
        else
        {
            //what if charge = -1??? 
            ChargeDirection = SwipeDirection;
            ChargeCount = 0;
        }
    }
    IEnumerator Combo(TouchManager.Direction Direction, int Stage)
    {
        StopGo();

        Comboing = true;
        ComboDirection = Direction;
        Debug.Log("Comboing to " + Direction + " at the power of " + Stage + "!");
        //immobilize
        Immobilized = true;

        _smoothFollow.TargetTransform = PlacesToBe[(int)Direction];

        yield return new WaitForSeconds(2.0f);


        Immobilized = false;
        //remobilize
        Debug.Log("Combo finished " + Direction);
        Comboing = false;
        ComboDirection = TouchManager.Direction.Nowhere;

        ReturnLane();
        yield break;
    }


    public void SetAnimatorVaribles()
    {


    }

    public void Stop()
    {
        Immobilized = true;
        _smoothFollow.Following = false;

        ResetStates();
    }

    public void Start()
    {
        Immobilized = false;
        _smoothFollow.Following = true;

        ResetStates();
    }
    
    public void ResetStates()
    {
        Going = false;
        GoDirection = TouchManager.Direction.Nowhere;

        ChargeCount = 0;
        ChargeDirection = TouchManager.Direction.Nowhere;

        Comboing = false;
        ComboDirection = TouchManager.Direction.Nowhere;
    }

    public void Die()
    {

        Debug.Log("I died");

        GameManager.Instance.GameOver();

    }
    
    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Enemy")
        {
            Die();
        }


    }



}
