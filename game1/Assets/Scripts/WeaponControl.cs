using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public LayerMask ObstacleLayer;
    public Vector3 Offfset;
    RaycastHit hit;
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity,ObstacleLayer))
        {
            transform.LookAt(hit.point);
            transform.rotation*= Quaternion.Euler(Offfset);
        }
    }
}
