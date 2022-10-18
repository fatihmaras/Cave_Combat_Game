using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponControl : MonoBehaviour

{
    public GameObject Hand;

    public LayerMask ObstacleLayer;
    public Vector3 Offfset;
    RaycastHit hit;

    public GameObject Bullet;
    public Transform FirePoint;

    private float CoolDown;

    public AudioClip GunShot;
    void Update()
    {
        //Look
        // if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, ObstacleLayer))
        // {
        //     Hand.transform.LookAt(hit.point);
        //     Hand.transform.rotation *= Quaternion.Euler(Offfset);
        // }

        // CoolDown

        if (CoolDown>0)
        {
            CoolDown -= Time.deltaTime;
        }

        //Shot
        if (Input.GetMouseButtonDown(0) && CoolDown<=0) 
        {
            //CreateBullet
            Instantiate(Bullet, transform.position, transform.rotation *Quaternion.Euler(0,0,0));

            //Reset CoolDown
            CoolDown = 0.25f;
            
            //Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(GunShot,0.7f);

            //Animation

            GetComponent<Animator>().SetTrigger("Shot");
        }
    }
}
