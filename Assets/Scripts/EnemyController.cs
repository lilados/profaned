using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy variables")]
    [SerializeField] public KnockBackController entityKb;

    [SerializeField] public Animator animator;

    public GameObject player;
    public float aggroRange = 5;
    public bool dead;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
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
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }


        if (gameObject.GetComponent<HealthManager>().health < 0 && !dead)
        {
            dead = true;    
            animator.SetBool("Dead", true);
        }
    }
}

