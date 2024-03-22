using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public Animator animator;
    public EnemyController enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("attack", true);
            enemy.isAttacking = true;
            enemy.CancelInvoke();
            enemy.wanderingFX.PlayOneShot(enemy.attackSound, 1);
            enemy.InvokeRepeating("RoarSound", enemy.startDelay + 5.0f, enemy.startRepeat);
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
