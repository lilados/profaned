using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                player.transform.position.z - 10);
        }
    }
}
