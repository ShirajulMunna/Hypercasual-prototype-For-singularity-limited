using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    public int currectHitNumber; 
    public float counter;
    public int rank;
    public GameObject impactEffects;

    void Start()
    {
        currectHitNumber = 1;
        
    }

    void Update()
    {
        CalculateHitCount();
    }

    void CalculateHitCount()
    {
        
        counter =  currectHitNumber * 100;
    }

    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "Developers")
        {
            currectHitNumber++;
          
           GameObject impact=Instantiate(impactEffects, target.transform.position, Quaternion.identity);
            Destroy(target.gameObject);
            Destroy(impact, 1f);
            Debug.Log("hit ");

            
        }

        if(target.gameObject.tag== "Finish")
        {
            
            GameManager.instance.pass += 1;
        }
    }

   
}
