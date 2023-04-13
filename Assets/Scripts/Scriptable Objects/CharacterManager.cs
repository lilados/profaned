using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    

    private int selectedOption = 0;

    

    public void NextOption()
    {
        characters[selectedOption].SetActive(false);
        selectedOption = (selectedOption + 1) % characters.Length;
        characters[selectedOption].SetActive(true);
    }

    public void BackOption()
    {
       characters[selectedOption].SetActive(false);
       selectedOption--;
       if (selectedOption < 0)
       {
           selectedOption += characters.Length;
       }
       characters[selectedOption].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedOption);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
