using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Magnet : MonoBehaviour
{
    private MeshRenderer _magnetMesh;
    public Color _meshColor;
    public float speed;
    public bool north, south;
  
    void Start()
    {
       
        _magnetMesh = GetComponent<MeshRenderer>();
        _magnetMesh.material.color = _meshColor;
      
    }

   
    
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall") 
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        }
       
    }

    public bool TrueFalse()
    {
        if (north)
            return true;
        else
            return false;
    }
  
}
