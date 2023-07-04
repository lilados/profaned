
using System;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;


public static class SetPolygonShape
{
    [Range(0, 1)]
    public static float ColliderComplexity = 0;
    public static void SetColliderFromSprite(GameObject gameObject)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        PolygonCollider2D polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
        Sprite sprite = spriteRenderer.sprite;
        Texture2D texture = sprite.texture;
        Vector2[] colliderPoints;
        float pixelWidth = 1 / sprite.pixelsPerUnit;

        int highest;
        int lowest;
        int leftest;
        int rightest;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {

                Color color = texture.GetPixel(x, y);
            }   
        }
        
        
    }

    
    private static void GetPoints()
    {
        
    }
}

