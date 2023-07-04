using System.Collections;
using SOs.Modifiers;
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
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
            Vector2 dir = (col.transform.position - gameObject.transform.position).normalized;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(dir*10, ForceMode2D.Impulse);


            StartCoroutine(Reset(col));
        }
    }

    private IEnumerator Reset(Collision2D col)
    {
        yield return new WaitForSeconds(0.2f);

        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    
    }
}
