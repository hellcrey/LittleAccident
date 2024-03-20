using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
      
            if (other.gameObject.CompareTag("PowerUp"))
            {
                Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            Debug.Log("You Loss!!");
        }
       
    }
}
