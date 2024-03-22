using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsHover : MonoBehaviour
{
    public AudioSource hoverFX;
    public AudioClip hoverClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HoverSound()
    {
        hoverFX.PlayOneShot(hoverClip);
    }
}
