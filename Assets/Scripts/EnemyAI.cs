using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy variables")]
    [SerializeField] public KnockBackController entityKb;
    [SerializeField] public Animator animator;

    public GameObject player;
    public float aggroRange = 5;
    public bool dead;
    public float attackInterval = 8, timeLeft;

    public virtual void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if (timeLeft <= attackInterval && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = attackInterval;
            animator.SetTrigger("Attack");
        }
        
    }
    public virtual void Update()
    {
        if (player == null)
        {
            player = Utility.GetClosestEnemy(GameObject.FindGameObjectsWithTag("Player"), transform);
        }
        
        float dist = Vector2.Distance(player.transform.position, gameObject.transform.position);
        
        animator.SetFloat("dist" , dist);
        
        if(dist < aggroRange) 
        {
            if (player.transform.position.x < transform.position.x)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }


        if (gameObject.GetComponent<HealthManager>().health < 0 && !dead)
        {
            dead = true;    
            animator.SetBool("Dead", true);
        }
    }
}

