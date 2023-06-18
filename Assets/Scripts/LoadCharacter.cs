using System;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject melee;
    public GameObject ranger;
    public GameObject mage;
    
    void Start()
    {
        melee.SetActive(false);
        ranger.SetActive(false);
        mage.SetActive(false);
        int selectedOption = PlayerPrefs.GetInt("selectedCharacter");
        {
            switch (selectedOption)
            {
                case 0:
                    melee.SetActive(true);
                    break;
                case 1:
                    ranger.SetActive(true);
                    break;
                case 2:
                    mage.SetActive(true);
                    break;
            }
        }
    }
    
    
}
