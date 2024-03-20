using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;


public class Enemigo : MonoBehaviour
{

    private NavMeshAgent agent;
    private Transform playerTransform;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTransform = FindAnyObjectByType<PlayerMovement>().transform;
    }


    void Update()
    {
        agent.destination = playerTransform.position;
    }
}
