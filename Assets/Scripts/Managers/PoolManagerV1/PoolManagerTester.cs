﻿using UnityEngine;
using System.Collections;

public class PoolManagerTester : MonoBehaviour {
	
	
	void Start()
    {

        //Debug.Log("sadasd");
        //PoolManager.Instance.Get(PoolManager.ObjectType.Enemy1);
        GameObject go = PoolManager.Instance.GetGameObject("Enemy1");
        go = PoolManager.Instance.GetGameObject("Enemy1");
        go = PoolManager.Instance.GetGameObject("Enemy1");
        go = PoolManager.Instance.GetGameObject("Enemy1");
        go = PoolManager.Instance.GetGameObject("Friend");
        go.transform.position = Vector3.down * 2;

    }
	
	
	
	
}
