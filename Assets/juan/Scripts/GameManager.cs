using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int collectibleNumber;

  
    public int totalCollectibleNumber;

    public Canvas winnerCanvas;



    void Start()
    {
        totalCollectibleNumber = transform.childCount;
    }


    void Update()
    {
        if (transform.childCount <= 0)
        {
            winnerCanvas.gameObject.SetActive(true);
            Debug.Log("YOU WIN");
        }
    }

}
