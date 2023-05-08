using System;
using UnityEngine;

public class FindGameObjects
{
        public void GetClosestGameObject(string tag)
        {
                GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

                if (gameObjects.Length == 0)
                {
                        
                }
                else
                {
                        foreach (GameObject gameObject in gameObjects)
                        {
                                
                        }
                }
        }
}