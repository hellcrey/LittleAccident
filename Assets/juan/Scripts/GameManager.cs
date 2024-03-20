using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private int collectibleNumber;

  
    private int totalCollectibleNumber;



    void Start()
    {
        totalCollectibleNumber = transform.childCount;
       
    }


    void Update()
    {
        if (transform.childCount <= 0)
        {
            Debug.Log("YOU WIN");
      
        }


    }
}
