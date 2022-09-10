using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool Player_Alive=true;
    public GameObject Death_Effect;
    public void Death()
    {
        if (Player_Alive)
        {
            Player_Alive = false;

            //Particle Effect 

            Instantiate(Death_Effect,transform.position,Quaternion.identity);
        }
    }
}
