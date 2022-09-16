using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Touch Lava

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().Death();
        }
    }
}
