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
    private LineRenderer line;
    public float LaserRange = 100f;
    
    private void Awake() {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        //Line Renderer
        if (Physics.Raycast(transform.position,transform.forward,out hit,LaserRange ,Obstacle))
        {
            LaserHit= true;
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);

            line.startWidth = 0.025f * LaserMultipler + Mathf.Sin(Time.time) / 80;
        }
        else
        {
            LaserHit = false;
            line.enabled = false;
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
