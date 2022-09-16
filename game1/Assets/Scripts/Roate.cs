using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roate : MonoBehaviour
{
    public Vector3 RotateAxis;
    public float Speed = 1f;
    void Update()
    {
        transform.Rotate(RotateAxis *Speed * Time.deltaTime);
    }
}
