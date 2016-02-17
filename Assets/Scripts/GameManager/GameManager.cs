using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    //public PlayerController player;


    void Awake()
    {
        StartCoroutine(DelayStart());
    }

    IEnumerator DelayStart()
    {

        yield return new WaitForSeconds(2);
        StartGame();

    }


    public void StartGame()
    {
        //start spawner
        //Spawner.Instance.StartSpawner();

        //start player
        //player.Start();
        
        EventManager.GameStartTrigger();
    }
	
    public void GameOver()
    {
        //stop spawner
        //Spawner.Instance.StopSpawner();

        //Collect all objects from scene
        //PoolManager.Instance.ReturnAllObjects();
        
        //stop player
        //player.Stop();

        //TriggerEvent
        EventManager.GameOverTrigger();       
    }
	
	


}
