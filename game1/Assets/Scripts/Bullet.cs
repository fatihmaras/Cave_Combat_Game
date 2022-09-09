using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float LifeTime = 5f;
   


    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        LifeTime-= Time.deltaTime;
        if (LifeTime<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
