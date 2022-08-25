using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;
    public GameObject inGame, leaderborad;
    public Text countText;


    
    void Awake()
    {
        instance = this;
        StartCoroutine(StartGame());
    }

    void Update()
    {
        if (GameManager.instance.failed)
        {
            if (leaderborad.activeInHierarchy)
            {
                GameManager.instance.failed = false;

            }
        }
    }

    IEnumerator StartGame()
    {
        countText.text = 3.ToString();
        yield return new WaitForSeconds(1);
        countText.color = Color.magenta;
        countText.text = 2.ToString();
        yield return new WaitForSeconds(1);
        countText.color = Color.yellow;
        countText.text = 1.ToString();
        yield return new WaitForSeconds(1);
        countText.color = Color.green;
        countText.text = "GO";
        GameManager.instance.start = true;
        yield return new WaitForSeconds(.5f);
        countText.gameObject.SetActive(false);

    }

    public void OpenLB()
    {

        //inGame.SetActive(false);
        leaderborad.SetActive(true);
        Time.timeScale = 0;
       
    }

  

   
}
