using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask Obstacle, Player_Layer;

    public GameObject DeathEffect;

    public float LaserMultipler = 1;
    
    void Update()
    {
        if (Physics.Raycast(transform.position,transform.forward,out hit,Mathf.Infinity,Obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.025f * LaserMultipler + Mathf.Sin(Time.time) / 80;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }


        //Kill Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity,Player_Layer))
        {
            hit.transform.gameObject.GetComponent<PlayerManager>().Death();
        }
    }
}
