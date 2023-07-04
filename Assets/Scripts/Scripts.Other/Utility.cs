using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility 
{
    public static float AngleTowardsMouse(Vector3 pos) {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(pos);
        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        return angle;
    }
    
    public static GameObject GetClosestEnemy(GameObject[] entities, Transform pivot)
    {
        GameObject closest = null;
        float smallest = 30;
            
            
        for (int i = 0; i < entities.Length; i++)
        {
            float dist = Vector3.Distance(entities[i].transform.position, pivot.position);
            if (dist < smallest)
            {
                smallest = dist;
                closest = entities[i];
            }
        }

        return closest;
    }
    
    
    public static GameObject GetFurthestEnemy(GameObject[] entities, Transform pivot)
    {
        GameObject furthest = null;
        float largest = 0;
            
            
        for (int i = 0; i < entities.Length; i++)
        {
            float dist = Vector3.Distance(entities[i].transform.position, pivot.position);
            if (dist > largest)
            {
                largest = dist;
                furthest = entities[i];
            }
        }

        return furthest;
    }

    public static float GetAngleBetweenGameObjects(GameObject pivot, GameObject target)
    {
        Vector3 pivotPos = target.transform.position;

        pivotPos.x -= pivot.transform.position.x;
        pivotPos.y -= pivot.transform.position.y;


        float angle = Mathf.Atan2(pivotPos.y, pivotPos.x) * Mathf.Rad2Deg;
        return angle;
    }

    public static GameObject GetGameObjectWithProjectile(GameObject sender, Projectile projectile)
    {
        GameObject prefab = Resources.Load<GameObject>("ProjectilePrefab");
        prefab.GetComponent<ProjectileMan>().proj = projectile;
        prefab.GetComponent<ProjectileMan>().proj.sender = sender;
        return prefab;
    }
}