using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float scale = 2;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groudnMask;
    public MenuManager menuManager;

    Vector3 velocity;
    bool isGrounded;

    public AudioSource powerUpFx;
    public AudioClip[] audioArray;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groudnMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
       
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 6;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arma"))
        {
            Debug.Log("Golpe");
            menuManager.GameOver();
            
        }
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            transform.localScale = new Vector3(scale, scale, scale);
            scale = 0.5f + scale;
            powerUpFx.PlayOneShot(audioArray[Random.Range(0,audioArray.Length)], 1);
            Debug.Log(scale);
        }
    }

}
