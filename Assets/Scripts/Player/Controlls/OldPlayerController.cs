using UnityEngine;
using System.Collections;

/*

[RequireComponent(typeof(SmoothFollow))]
public class PlayerController : MonoBehaviour {

    

    //For Debug.
    public Material MyMat;

    public Transform[] PlacesToBe;
    public Transform[] ComboPlaces;
    private SmoothFollow _smoothFollow;

    public float Return_Time = 1.0f;
    
    public bool Going;
    public TouchManager.Direction GoDirection;

    public int ChargeCount;
    public TouchManager.Direction ChargeDirection;

    public bool Comboing;
    public TouchManager.Direction ComboDirection = TouchManager.Direction.Nowhere;

    public bool Immobilized;

    private Coroutine GoCoroutine;
    ///private IEnumerator ComboCoroutine; 

    
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
        

        // new code
        //ComboCoroutine = Combo();

        TouchManager.Instance.playerController = this;

        EventManager.GameOverEvent += Stop;
        EventManager.GameStartEvent += Start;

    }

    void Update()
    {
        //set animator thingies
        SetAnimatorVaribles();

        
    }

	public void Swipe(TouchManager.Direction SwipeDirection)
	{
        //Debug.Log("Player Knows Human Swiped: " + SwipeDirection);

        if (Immobilized) return;

        HandleCharge(SwipeDirection);
        HandleGo(SwipeDirection);
	}
    
    void HandleGo(TouchManager.Direction SwipeDirection)
    {
        
        StopGo();
        
        GoDirection = SwipeDirection;
        //StartCoroutine("Go", SwipeDirection);
        GoCoroutine = StartCoroutine(Go());
    }
    IEnumerator Go ()
    {

        Going = true;

        _smoothFollow.TargetTransform = PlacesToBe[(int)GoDirection];


        yield return new WaitForSeconds(Return_Time);

        Going = false;
        GoDirection = TouchManager.Direction.Nowhere;

        ReturnLane();

        yield break;
    }
    void StopGo()
    {
        if(GoCoroutine != null)
            StopCoroutine(GoCoroutine);
        GoCoroutine = null;
        Going = false;
    }
    void ReturnLane()
    {
        Debug.Log("returning");
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
                    StopCoroutine("Go"); //Todo This isnt working
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

        _smoothFollow.TargetTransform = ComboPlaces[(int)Direction];

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
        //for debug
        if (Comboing)
        {
            MyMat.color = Color.red;
        }
        else
        {
            MyMat.color = Color.blue;
        }

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

        //Debug.Log("I died");

        GameManager.Instance.GameOver();

    }
    
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdasd");
        
        if(other.tag == "Enemy")
        {

            if (Comboing)
            {
                PoolManager.Instance.ReturnObject(other.gameObject);
            }
            else
            {
                Die();
            }
        }





    }

    
    
}

*/
