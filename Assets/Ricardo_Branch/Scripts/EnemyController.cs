using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int routine;
    public float timer;
    public Animator animator;
    public Quaternion angle;
    public float degree;

    public GameObject target;
    public bool isAttacking;
    public EnemyRange range;

    public NavMeshAgent agent;
    public float attackDistance;
    public float sightDistance;
    public float speed;

    public AudioSource wanderingFX;
    public AudioClip wanderingClip;
    public AudioClip attackSound;

    public int startDelay;
    public int startRepeat;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("FirstPersonPlayer");
        sightDistance = PlayerPrefs.GetInt("Level");
        InvokeRepeating("RoarSound", startDelay, startRepeat);

    }

    // Update is called once per frame
    void Update()
    {
        EnemyBehaivor();
    }
    public void EnemyBehaivor()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > sightDistance)
        {
            agent.enabled = false;
            animator.SetBool("run", false);
            timer += 1 * Time.deltaTime;
            if (timer >= 4)
            {
                routine = Random.Range(0, 2);
                timer = 0;
            }
            switch (routine)
            {
                case 0:
                    animator.SetBool("walk", false);
                    break;

                case 1:
                    degree = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, degree, 0);
                    routine++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    animator.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            agent.enabled = true;
            agent.SetDestination(target.transform.position);

            if(Vector3.Distance(transform.position, target.transform.position) > attackDistance && !isAttacking)
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
            }
            else
            {
                if (!isAttacking)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 1);
                    animator.SetBool("walk", false);
                    animator.SetBool("run", true);
                }
            }
        }
        if(isAttacking)
        {
            agent.enabled = false;  
        }

    }
    public void EndAttack()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > attackDistance + 0.2f)
        {
            animator.SetBool("attack", false);
            
        }
        isAttacking = false;
        range.GetComponent<CapsuleCollider>().enabled = true;

    }
    public void RoarSound()
    {
        wanderingFX.PlayOneShot(wanderingClip, 1f);
    }

}
