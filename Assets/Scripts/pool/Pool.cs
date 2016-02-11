using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool : MonoBehaviour {
    
    private List<GameObject> Objects = new List<GameObject>();
    
    public GameObject One
    {

        get {
            if (Objects.Count > 0)
            {
                //if there is an object in pool
                GameObject ToReturn = Objects[0];
                Objects.RemoveAt(0);
                

                //Dont lose the referance
                //Why? i dont know!
                //nevermind, i deleted it

                return ToReturn;
            }
            //else then make a new object


            //todo fill


            Debug.LogError("::ERROR WE CANT INSTANTIATE A NEW OBJECT IN POOL."+
                            " WE ARE PRETTY FUCKED UP RIGHT NOW:::");
            //aaw nevermind i can give him a cube. that will solve it
            return GameObject.CreatePrimitive(PrimitiveType.Cube); 
        }
    }

    public void Add(GameObject ToGive)
    {
        //deactivate object before pooling
        ToGive.SetActive(false);

        //And Add to pool as usual
        Objects.Add(ToGive);
    }

    public void InstantiatePool(GameObject Original, int Size)
    {

        for (int i = 0; i < Size; i++)
        {
            //make a new Object From Original
            GameObject ToAdd = Instantiate(Original);
            
            //Deactivate clone
            ToAdd.SetActive(false);
            
            //Add to Pool
            Objects.Add(ToAdd);
        }

    }
    
}
