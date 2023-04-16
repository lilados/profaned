using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeKnockback(Vector2 force, float time)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        StartCoroutine(StopKB(time, gameObject.GetComponent<Rigidbody2D>()));
    }

    private IEnumerator StopKB(float time, Rigidbody2D rb)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.zero;
    }
}
