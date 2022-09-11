using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform Player;
   

    public float Speed = 1;
    public float Follow_Distance = 10f;

    private float CoolDown = 2f;

    public GameObject Mesh;

    public GameObject Bullet;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
    }

    private void FollowPlayer()
    {
        //Look to Player
        transform.LookAt(Player.position);
        transform.rotation *= Quaternion.Euler(new Vector3(0,180,0));

        //Move to Player
        if (Vector3.Distance(transform.position,Player.position)>= Follow_Distance) 
        {
            transform.Translate(transform.right * Time.deltaTime * Speed);
        }
        else
        {
            transform.RotateAround(Player.position, transform.up, Time.deltaTime * Speed* Random.Range(0.2f,3f));
        }
        

    }

    private void Shot()
    {
        if (CoolDown > 0)
        {
            CoolDown -= Time.deltaTime;
        }
        else
        {
            CoolDown = 2f;

            //Shot

            Mesh.GetComponent<Animator>().SetTrigger("Shot");
            Instantiate(Bullet, transform.position, transform.rotation*Quaternion.Euler(0,180,0));


        }
    }
}
