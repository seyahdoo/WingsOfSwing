using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {



    void Awake()
    {

        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        g.AddComponent<Tester>();



    }









}
