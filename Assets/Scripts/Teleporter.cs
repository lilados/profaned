using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public float teleportTime;

    public float timeLeftToTeleport;
    public bool teleporting;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        timeLeftToTeleport = teleportTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!teleporting && timeLeftToTeleport > 0)
        {
            timeLeftToTeleport -= Time.deltaTime;
        }
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        teleporting = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (timeLeftToTeleport < teleportTime)
        {
            timeLeftToTeleport += Time.deltaTime;
        }
    }

    public void Teleport()
    {
        
    }

    public void TeleportOntoScene()
    {
        
    }
}
