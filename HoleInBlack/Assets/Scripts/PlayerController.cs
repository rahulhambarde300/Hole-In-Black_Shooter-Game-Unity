using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Boundary
{ /// <summary>
/// This is to give boundary to the player window
/// </summary>
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public Boundary boundary;
    public float velocity = 10;
    public float turnSpeed = 10;

    public GameObject BlackHole;
    public Transform SpawnShot;
    private Transform player;



    Vector2 input;
    float angle;

    public float fireRate = 1;
    public float nextFire = 0;

    Quaternion targetRotation;

    Vector3 screenWidth;
    Vector3 screenHeight;

    public GameObject PauseUI;
    private bool paused;

    void Start() {
        player = gameObject.transform;
        ///To teleport the ship when its at boundary
        screenWidth = new Vector3(boundary.xMax - boundary.xMin, 0f, 0f);
        screenHeight = new Vector3(0f, 0f, boundary.zMax - boundary.zMin);
        // FindObjectOfType<AudioManager>().Play("ShipMovement");
        paused = false;
    }
         



    void Update() {
        GetInput();
        if (Input.GetButton("Fire1") && Time.time>nextFire ) {
            nextFire = Time.time + fireRate;
            Instantiate(BlackHole, SpawnShot.position, SpawnShot.rotation) ;
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown("escape"))
        {
            if (!paused)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0f;
                paused = true;
            }
            else
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1f;
                paused = false;
            }
        }
        
        ///If there is input invoke those functions 
        if(Mathf.Abs(input.x)<1 && Mathf.Abs(input.y)<1)
            return;
 
        CalculateDirection();
        Rotate();
        Move();
        
    }
    void FixedUpdate()
    {
        ///Check if the ship is at boundary
        if (player.position.x >= boundary.xMax)
            player.position -= screenWidth;
        else if (player.position.x <= boundary.xMin)
            player.position += screenWidth;
        else if (player.position.z >= boundary.zMax)
            player.position -= screenHeight;
        else if (player.position.z <= boundary.zMin)
            player.position += screenHeight;
    }

    void GetInput() {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
       

    }

    void Rotate() {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,turnSpeed*Time.deltaTime);
    }

    void Move() {
        transform.position += transform.forward * velocity * Time.deltaTime;
        

    }

}