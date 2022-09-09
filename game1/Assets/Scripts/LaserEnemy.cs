using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask Obstacle, Player_Layer;
    
    void Update()
    {
        if (Physics.Raycast(transform.position,transform.forward,out hit,Mathf.Infinity,Obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.025f + Mathf.Sin(Time.time) / 80;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity,Player_Layer))
        {
            Destroy(hit.transform.gameObject);

        }
    }
}
