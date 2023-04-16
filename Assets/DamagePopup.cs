using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = GameObject.Find("Canvas").transform;
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
