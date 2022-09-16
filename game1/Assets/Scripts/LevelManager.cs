using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Player Enter-Exit
    public bool PlayerEnter, PlayerExit;

    //DroneSpawn
    public bool DroneSpawn = false;
    public Transform [] DroneSpawner;
    public GameObject Drone;

    private void Update()
    {
        //Drone Spawn 
        if (!DroneSpawn && PlayerEnter)
        {

            for (int i = 0; i<DroneSpawner.Length; i++)
            {
                Instantiate(Drone, DroneSpawner[i].position, Quaternion.identity);
            }
            
            DroneSpawn=true;
        }
    }
}
