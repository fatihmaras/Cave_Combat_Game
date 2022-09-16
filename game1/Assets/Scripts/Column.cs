using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Transform Checker;
    public LayerMask PlayerLayer;
    // public GameObject ColumnMesh;

    public float Radius;

    public Vector3 Velocity;

    private bool Broken = false;

    public float ColumnDivide;


    private void Update()
    {
        if (Physics.CheckBox(Checker.position, new Vector3(Radius, 2, Radius), Quaternion.identity, PlayerLayer))
        {
            print("okay");
            Broken = true;
        }
        if (Broken)
        {
            Velocity.y -= Time.deltaTime / ColumnDivide;
           transform.Translate(Velocity);
        }
    }
    

}
