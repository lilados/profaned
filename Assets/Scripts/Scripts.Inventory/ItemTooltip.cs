using TMPro;
using UnityEngine;
using Weapons;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ItemNameText;
    [SerializeField] TextMeshProUGUI ItemTypeText;
    [SerializeField] TextMeshProUGUI ItemDescriptionText;

    public TMP_ColorGradient[] gradients;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowTooltip(Item item)
    {
        ItemNameText.text = item.ItemName;
        ItemNameText.gameObject.GetComponent<TextMeshProUGUI>().colorGradientPreset = gradients[item.rarity];
        if (item is EquippableItem)
        {
            if (item is MeleeWeapon) ItemTypeText.text = "Melee Weapon"; 
            else if(item is RangedWeapon) ItemTypeText.text = "Ranged Weapon";
            else if(item is MagicWeapon) ItemTypeText.text = "Magic Weapon";
            else{
                ItemTypeText.text = item.GetItemType();
            }
        }
        else
        {
            ItemTypeText.text = "Material";
        }
        ItemDescriptionText.text = item.GetDescription();
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}