using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    private Animator _anim;
    private int levelToLoad;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void FadeToLevel(int index) 
    {
        levelToLoad = index;
        _anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() 
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
