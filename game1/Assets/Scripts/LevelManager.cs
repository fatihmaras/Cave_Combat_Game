using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Player Enter-Exit
    public bool PlayerEnter, PlayerExit;

    //DroneSpawn
    private bool Spawn = false;
    public Transform[] DroneSpawner;
    public GameObject Drone;

    //LevelSpawn
    public GameObject Level;
    public GameObject Destroy_Level;

    private void Awake()
    {
        PlayerEnter = false;
        Spawn = false;
    }

    private void Update()
    {
        // Spawn 
        if (!Spawn)
        {
            if (PlayerEnter)
            {
                //DroneSpawn
                for (int i = 0; i < DroneSpawner.Length; i++)
                {
                    Instantiate(Drone, DroneSpawner[i].position, Quaternion.identity);
                }

                //LevelSpawn
                SpawnLevel();

                //Set Bool
                Spawn = true;

            }
        }
        //DestroyLevel
        if (PlayerExit)
        {
            if (Destroy_Level != null)
            {
                Destroy(Destroy_Level);


            }
        }
    }

    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x + 104, transform.position.y, transform.position.z);
        GameObject obj = Instantiate(Level, pos, Quaternion.identity);
        obj.GetComponent<LevelManager>().Destroy_Level = this.gameObject;
    }

}





