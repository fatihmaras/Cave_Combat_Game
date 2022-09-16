using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask Obstacle, Player_Layer;

    public GameObject DeathEffect;

    public float LaserMultipler = 1;

    private bool LaserHit;

    public float LaserRange = 100f;
    
    void Update()
    {
        //Line Renderer
        if (Physics.Raycast(transform.position,transform.forward,out hit,LaserRange ,Obstacle))
        {
            LaserHit= true;
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.025f * LaserMultipler + Mathf.Sin(Time.time) / 80;
        }
        else
        {
            LaserHit = false;
            GetComponent<LineRenderer>().enabled = false;
        }


        //Kill Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, LaserRange,Player_Layer))
        {
            if (LaserHit)
            {
                hit.transform.gameObject.GetComponent<PlayerManager>().Death();
            }
            
        }
    }
}
