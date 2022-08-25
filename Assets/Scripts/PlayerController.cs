using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private Joystick _joySticks;
    private Rigidbody _playerRb;
    private Transform _playerBody;
    public float speed,force;
    
    private float lastClickedTime;
    public float range;
    public Transform target;
    public bool playerCurrentState;
    public bool magnetCurrentState;
    public bool isAttracted;

    public float lerpTime;
    public float lTime;

    public Vector3 playerOffset;

    private Animator anim;
    public Transform objectToMove;
   [SerializeField] private Camera gameCamera;
    private RaycastHit hitInfo;

  


    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _joySticks = FindObjectOfType<Joystick>();
        _playerBody = GetComponent<Transform>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        gameCamera = Camera.main;
        gameObject.name = PlayerPrefs.GetString("PlayerName","Player");
       

    }

    void Update()
    {
        UpdateTarget();
        float xAxis = _joySticks.Horizontal;
        float zAxis = _joySticks.Vertical;

        Vector3 movementDirection = new Vector3(-xAxis, 0, -zAxis);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
            anim.SetFloat("Speed", 1f);

        }
        else if (movementDirection == Vector3.zero)
        {
            anim.SetFloat("Speed", 0f);
        }






        if (Input.GetMouseButtonDown(0)) 
        {
            float timeSinceLastClick = Time.time - lastClickedTime;
            lastClickedTime = Time.time;
            

            if (timeSinceLastClick <= 0.2f) 
            {
                Debug.Log("Double click");
                ForcePlayer();
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish Line") 
        {
            FindObjectOfType<SceneFader>().FadeToLevel(0);
        }
    }

    public void ForcePlayer() 
    {
        _playerRb.AddForce(transform.forward* force );
    }


    public void UpdateTarget()
    {

        GameObject[] players = GameObject.FindGameObjectsWithTag("Magnet");
        float shortDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in players) 
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < shortDistance)
            {
                shortDistance = distanceToPlayer;
                nearestPlayer = player;
            }

        }
        
        if (nearestPlayer != null && shortDistance <= range)
        {
            target = nearestPlayer.transform;
            playerCurrentState = GetComponent<PlayerColorChanger>().TrueFalse();
            magnetCurrentState = target.GetComponent<Magnet>().TrueFalse();
            Debug.Log("playerCurrentState " + playerCurrentState);

            if (playerCurrentState && !magnetCurrentState)
            {             
                transform.position = Vector3.Lerp(transform.position, target.position+playerOffset, lerpTime);
            }
            else if (!playerCurrentState && magnetCurrentState)
            {

                transform.position = Vector3.Lerp(transform.position, target.position+ playerOffset, lerpTime);
            }
            else
            {
                Debug.Log("matched color");
                _playerRb.AddForce(-(target.transform.position - transform.position) * force);         
            }

        }
        else
        {
            target = null;

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }


}
