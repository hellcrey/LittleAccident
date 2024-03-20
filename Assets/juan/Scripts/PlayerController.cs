using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float scale = 2;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            transform.localScale= new Vector3(scale, scale, scale);
            scale++;
            Debug.Log(scale);

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            Debug.Log("You Loss!!");
        }
       
    }
}
