using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int damage = 2;
    private void OnCollisionEnter2D(Collision2D col)
    {

        playerHealth = col.gameObject.GetComponent<PlayerHealth>();
        if (col.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
            playerHealth.timeLeft = 6.0f;
        }
    }
}
