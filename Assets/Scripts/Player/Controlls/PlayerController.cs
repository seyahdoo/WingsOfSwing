using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(SmoothFollow))]
public class PlayerController: MonoBehaviour {

    public bool DEBUG = false;

    public Material MyMat;

    public Transform[] PlacesToBe;
    public Transform[] ComboPlaces;
    private SmoothFollow _smoothFollow;

    public float Go_Return_Time = 1.0f;
    public float Combo_Return_Time = 2.0f;
    Timer GoTimer = new Timer();
    Timer ComboTimer = new Timer();

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

        TouchManager.Instance.playerController = this;

        EventManager.GameOverEvent += Stop;
        EventManager.GameStartEvent += Start;

        //if mat == null : get mat
    } 
    void Update()
    {        
        //Work with timers, becouse its cool, like hitler(hit's)
        GoReturnLogic();
        ComboReturnLogic();
    }
    
    public void Swipe(TouchManager.Direction SwipeDirection)
    {
        if (Immobilized) return;

        HandleGo(SwipeDirection);
        HandleCharge(SwipeDirection);
    }
    
    void HandleGo(TouchManager.Direction Direction)
    {

        Going = true;
        GoDirection = Direction;
        _smoothFollow.TargetTransform = PlacesToBe[(int)Direction];
        GoTimer.SetTimer(Go_Return_Time);

        //what if we are comboing
        Comboing = false;
        ComboDirection = TouchManager.Direction.Nowhere;
        ComboTimer.SetActive(false);
        MyMat.color = Color.blue;
        
    }
    void GoReturnLogic()
    {
        //after seconds
        if (!GoTimer.Contunie) return;
        
        Going = false;
        GoDirection = TouchManager.Direction.Nowhere;
        _smoothFollow.TargetTransform = PlacesToBe[(int)TouchManager.Direction.Down];

        //reset Charge
        ChargeCount = 0;
        ChargeDirection = TouchManager.Direction.Nowhere;
    }
    
    void HandleCharge(TouchManager.Direction Direction)
    {

        //HandleCharging,Combo
        if (ChargeCount >= 0)
        {
            if (Direction == ChargeDirection)
                ChargeCount++;

            if (Direction != ChargeDirection)
            {
                if (ChargeCount >= 1)
                {
                    //Stop go Timer
                    GoTimer.SetActive(false);

                    //Start Combo(Direction, charge count)
                    Combo(Direction,ChargeDirection, ChargeCount);

                    //reset Handler
                    ChargeCount = 0;
                    ChargeDirection = TouchManager.Direction.Nowhere;
                }
                else
                {
                    ChargeCount = 0;
                    ChargeDirection = Direction;
                }

            }
        }
        else
        {
            //what if charge = -1??? 
            ChargeDirection = Direction;
            ChargeCount = 0;
        }


    }
    void Combo(TouchManager.Direction ToDirection, TouchManager.Direction FromDirection, int Power)
    {
        //Combo Start!
#if UNITY_EDITOR
        if (DEBUG) Debug.Log("Combo Start");
#endif
        Comboing = true;
        ComboDirection = ToDirection;
        if (DEBUG) Debug.Log("Comboing to " + ToDirection + " From "+ FromDirection + " at the power of " + Power + "!");
        
        //immobilize
        //Immobilized = true;

        _smoothFollow.TargetTransform = ComboPlaces[(int)ToDirection];

        ComboTimer.SetTimer(Combo_Return_Time);

        //change color
        if(FromDirection == TouchManager.Direction.Down)
            MyMat.color = Color.cyan;
        else if(FromDirection == TouchManager.Direction.Up)
            MyMat.color = Color.green;
        else 
            MyMat.color = Color.red;


    }
    void ComboReturnLogic()
    {
        //after seconds
        if (!ComboTimer.Contunie) return;

        if (DEBUG) Debug.Log("Combo Returned");
        
        Comboing = false;
        ComboDirection = TouchManager.Direction.Nowhere;

        //return line
        _smoothFollow.TargetTransform = PlacesToBe[(int)TouchManager.Direction.Down];

        //remobilize
        //Immobilized = false;

        //change color
        MyMat.color = Color.blue;
    }


    public void Stop()
    {
        Reset();
        Immobilized = true;
    }
    public void Start()
    {
        Reset();
        Immobilized = false;
    }
    public void Reset()
    {
        //todo write some stuff here
        

    }




    public void Die()
    {

        //Debug.Log("I died");

        GameManager.Instance.GameOver();

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdasd");

        if (other.tag == "Enemy")
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
