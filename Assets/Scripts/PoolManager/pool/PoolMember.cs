using UnityEngine;
using System.Collections;

public class PoolMember : MonoBehaviour {

    //TODO Write some elegant stuff here.

    public bool InPool;

    [ContextMenuItem("Return to Pool", "ReturnPool")]

    public Pool MyPool;

    //private void returnPoolContextFunction()
    //{
    //    ReturnPool();
    //}

    void Awake()
    {
        EventManager.GameOverEvent += OnGameOver;
    }

    public void OnPoolEnter()
    {
        transform.parent = MyPool.transform;
        //StartCoroutine(ReturnToPapaPool());
        
        gameObject.SetActive(false);
        //EventManager.GameOverEvent -= ReturnPool;

        InPool = true;
    }

    public void OnPoolOut()
    {
        transform.parent = null;
        gameObject.SetActive(true);

        //Return to pool on GameOver
        //EventManager.GameOverEvent += ReturnPool;

        InPool = false;
    }

    //void OnDisable()
    //{
    //    //Debug.Log("i been disabled, returning to pool");
    //    
    //    ReturnPool();
    //}

    public void ReturnPool()
    {
        MyPool.ReturnOld(gameObject);
    }

    void OnGameOver()
    {
        //Debug.Log("On Game Over");

        if (!InPool)
            ReturnPool();

    }


}
