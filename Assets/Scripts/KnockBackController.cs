using System.Collections;
using UnityEngine;

public class KnockBackController : MonoBehaviour
{
    public void TakeKnockBack(Vector2 force, float time)
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        StartCoroutine(StopKb(time, gameObject.GetComponent<Rigidbody2D>()));
    }

    private IEnumerator StopKb(float time, Rigidbody2D rb)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.zero;
    }
}
