using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public InputField playerName;

    public Text currentLevelText, nextLevelText;

    void Start()
    {
      
        if(PlayerPrefs.GetInt("FirstTime", 0) == 0)
            PlayerPrefs.SetInt("FirstTime", 1);
        else
            playerName.text = PlayerPrefs.GetString("PlayerName");
            
    }

    public void StartGame()
    {
        if (playerName.text == "")
            PlayerPrefs.SetString("PlayerName", "Player");
        else
            PlayerPrefs.SetString("PlayerName", playerName.text);


        SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));
    }
}
