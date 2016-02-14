using UnityEngine;
using System.Collections;

public class PoolMember : MonoBehaviour {

    //TODO Write some elegant stuff here.

    [ContextMenuItem("Return to Pool", "returnPoolContextFunction")]
    public Pool MyPool;

    private void returnPoolContextFunction()
    {
        ReturnPool();
    }


    public void OnPoolEnter()
    {
        transform.parent = MyPool.transform;
        //StartCoroutine(ReturnToPapaPool());
        
        gameObject.SetActive(false);
    }

    public void OnPoolOut()
    {
        transform.parent = null;
        gameObject.SetActive(true);
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


}
