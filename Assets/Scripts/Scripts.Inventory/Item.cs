using System;
using System.Text;
using Scripts.Inventory;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [HideInInspector][SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    public Sprite Icon;
    public int rarity;
    [Range(1,999)]
    public int MaximumStacks = 1;
    [Space]
    public RuntimeAnimatorController animator;

    protected static readonly StringBuilder sb = new StringBuilder();

	protected virtual void OnValidate()
	{
        
	}

    
    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }

    public virtual string GetItemType()
    {
        return "";
    }

    public virtual string GetDescription()
    {
        return "";
    }
}