using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    public AudioSource footStepsSound, sprintSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footStepsSound.enabled = false;
                sprintSound.enabled = true;
            }
            else
            {
                footStepsSound.enabled = true;
                sprintSound.enabled = false;
            }

        }
        else
        {
            footStepsSound.enabled = false;
            sprintSound.enabled = false;
        }
       
    }
}
