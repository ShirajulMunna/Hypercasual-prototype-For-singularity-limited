using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Controller : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public GameObject ground;
    private NavMeshAgent _naveMeshAgent;
    private Bounds _bounds;
    private Animator anim;

    void Start()
    {
        _naveMeshAgent = GetComponent<NavMeshAgent>();
        _bounds = ground.GetComponent<Renderer>().bounds;
        anim = transform.GetChild(0).GetComponent<Animator>();
        gameObject.name = Names.BotNames[Random.Range(0, Names.BotNames.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", 1f);

        if (_naveMeshAgent.hasPath == false || _naveMeshAgent.remainingDistance < 1.0f) 
        {
            float wait = Random.Range(minTime, maxTime);
            Invoke("PickrandomDdestination", wait);
        
        }
        
    }

    public void PickrandomDdestination() 
    {
        float rx = Random.Range(_bounds.min.x, _bounds.max.x);
        float rz = Random.Range(_bounds.min.z, _bounds.max.z);

        Vector3 rpos = new Vector3(rx, transform.position.y, rz);
        _naveMeshAgent.SetDestination(rpos);



    }
}
