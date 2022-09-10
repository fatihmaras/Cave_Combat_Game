using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Transform Checker;
    public LayerMask PlayerLayer;

    public float Radius;

    private Vector3 Velocity;

    private bool Broken = false;


    private void Update()
    {
        if (Physics.CheckBox(Checker.position, new Vector3(Radius,2,Radius), Quaternion.identity,PlayerLayer))
        {
            Broken = true;
        }
        if (Broken)
        {
            Velocity.z -= Time.deltaTime / 200;
            transform.Translate(Velocity);
        }
    }
    

}
