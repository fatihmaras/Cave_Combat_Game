using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float LifeTime = 5f;
   
    public bool EnemyBullet=false;
    public float BulletRadius = 0.5f;
    public LayerMask PlayerLayer;

    public GameObject HitParticleEffect;

    public AudioClip HitToDrone;


    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        LifeTime-= Time.deltaTime;
        if (LifeTime<=0)
        {
            Destroy(this.gameObject);
        }

        // Enemy Bullet
        if (EnemyBullet)
        {
            if (Physics.CheckSphere(transform.position,BulletRadius,PlayerLayer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //hit to Enemy
        if (other.CompareTag("Enemy"))
        {
            GameObject Drone = other.transform.parent.gameObject;
            Drone.GetComponent<Drone>().Health -= 25;
            Drone.GetComponent<AudioSource>().PlayOneShot(HitToDrone,0.5f);
            


        }

        Instantiate(HitParticleEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);


    }
}
