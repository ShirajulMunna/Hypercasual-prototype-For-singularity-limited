using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorShifter : MonoBehaviour
{
    MeshRenderer _playerMesh;
    [SerializeField] [Range(0f, 3f)] float lerpTime;
    [SerializeField] Color[] myColor;
    int colorIndex;
    float t;
    int len;
    void Start()
    {
        _playerMesh = GetComponent<MeshRenderer>();
        len = myColor.Length;
    }

    
    void Update()
    {


         
        _playerMesh.material.color = myColor[colorIndex];

        t = Mathf.Lerp(t, 3f, lerpTime * Time.deltaTime);
        Debug.Log(t);

        if (t > 2.9f) 
        {
            t = 0f;
            colorIndex++;
            Debug.Log("Color index"+colorIndex);
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
