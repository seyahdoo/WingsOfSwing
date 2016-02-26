//using UnityEngine;
//using System.Collections;
//
//public class TouchManagerV2 : Singleton<TouchManagerV2> {
//    ///check all touches and if got a move send it to player!s
//
//    protected TouchManagerV2() { }    //guarantee this will be always a singleton only - can't use the constructor!
//
//
//
//    public bool Touching = false;
//
//    public Vector2 StartPoint;
//
//    public float DragTreshold = 20;
//    public float SwipeTreshold = 40;
//
//    public float TouchTimeout = 1.0f;
//    private float _touchStartTime;
//
//    public PlayerController playerController;
//
//    void Update()
//    {
//
//        //If Some Touch Started
//        if (Touching == false && Input.GetMouseButtonDown(0))
//        {
//            Touching = true;
//            //Debug.Log ("A Touch Is Started(Mouse Emulated!)");
//            TouchStart(Input.mousePosition);
//        }
//
//        //		//If Touch contunies
//        //		if (Touching == true && !Input.GetMouseButtonDown (0)) {
//        //			TouchHover (Input.mousePosition);
//        //		}
//
//        //If Some Touch Ended
//        if (Touching == true && Input.GetMouseButtonUp(0))
//        {
//            Touching = false;
//            //Debug.Log ("A Touch Is Ended(Mouse Emulated!)");
//            TouchEnd(Input.mousePosition);
//        }
//
//
//    }
//
//
//
//    void TouchStart(Vector2 StartPoint)
//    {
//        //Debug.Log ("Touch Started at " + StartPoint);
//        //Debug.Log( CalculateAreaFromPixels(StartPoint));
//        this.StartPoint = StartPoint;
//        //get Touch start time
//        _touchStartTime = Time.time;
//    }
//
//    //	void TouchHover(Vector2 HoverPoint)
//    //	{
//    //		//Debug.Log ("Touch Contunies at " + HoverPoint);
//    //	}
//
//
//    void TouchEnd(Vector2 EndPoint)
//    {
//        //Touch time outs if pressed too long
//        if ((Time.time - _touchStartTime) > TouchTimeout)
//            return;
//
//        //Debug.Log ("Touch Ends at " + EndPoint);
//        var dif = EndPoint - StartPoint;
//        if (dif.magnitude < DragTreshold)
//        {
//            //then clicked
//            //Debug.Log("Clicked " + CalculateAreaFromPixels(StartPoint));
//
//        }
//
//        if (dif.magnitude > SwipeTreshold)
//        {
//            //then swiped
//            //Debug.Log(dif);
//            Debug.Log ("Swiped" + CalculateDirectionFromVector (dif));
//            playerController.Go(CalculateDirectionFromVector(dif));
//        }
//    }
//
//    public Direction CalculateDirectionFromVector(Vector2 Vector)
//    {
//        //if x value > y
//        if (Mathf.Abs(Vector.x) > Mathf.Abs(Vector.y))
//        {
//            //then swiped on x axis
//            if (Vector.x > 0)
//            {
//                return Direction.Right;
//            }
//            return Direction.Left;
//        }
//
//        //then swiped on y Axis
//        if (Vector.y > 0)
//        {
//            return Direction.Up;
//        }
//
//        return Direction.Down;
//    }
//
//    public Direction CalculateAreaFromPixels(Vector2 Pixels)
//    {
//        if (Screen.width / 3 > Pixels.x)
//        {
//            return Direction.Left;
//        }
//
//        if ((Screen.width * 2 / 3) < Pixels.x)
//        {
//            return Direction.Right;
//        }
//
//        if (Screen.height / 2 > Pixels.y)
//        {
//            return Direction.Down;
//        }
//
//        return Direction.Up;
//    }
//
//    public enum Direction
//    {
//        Down = 0,
//        Up = 1,
//        Left = 2,
//        Right = 3
//    }
//
//}



