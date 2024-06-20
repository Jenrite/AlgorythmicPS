using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager gameManager = GameManager.Instance;

            if (gameManager != null)
            {

                gameManager.Health--; 
            }
        }
    }
}
