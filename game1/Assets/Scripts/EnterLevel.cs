using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public LevelManager LM;

    public bool Enter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Enter)
            {
                LM.PlayerEnter = true;
            }
            else
            {
                LM.PlayerExit = true;
            }
        }
    }
}
