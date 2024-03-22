using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotation : MonoBehaviour
{
    public float rotationSpeedX = 10.0f;
    public float rotationSpeedY = 10.0f;
    public float rotationSpeedZ = 10.0f;
    public float maxScale;
    public float minScale;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime);
        transform.localScale = Vector3.one * (Mathf.PingPong(Time.time, maxScale) + minScale);

    }
}
