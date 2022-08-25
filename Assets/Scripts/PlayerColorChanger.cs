using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    MeshRenderer _playerMesh;
    public bool isBlue;
    public bool isRed;



    void Start()
    {
        _playerMesh = GetComponent<MeshRenderer>();

        StartCoroutine(ChangeColor());     
         
    }

    public IEnumerator ChangeColor()
    {
        while (true)
        {
            _playerMesh.material.color = Color.blue;
            isBlue = true;
            isRed = false;
            yield return new WaitForSeconds(5f);
            _playerMesh.material.color = Color.red;
            isBlue = false;
            isRed = true;
            yield return new WaitForSeconds(5f);

        }

    }

    public bool TrueFalse() 
    {
        if (isBlue)
            return true;
        else
            return false;      
    }  
    
}
