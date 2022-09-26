using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    //variables
    public PlayerActionMap playerInput;//to get input variables
    public static playerController instance;//instance of player controller
    Vector2 velocity;
    Vector2 rotation;


    Rigidbody body;
    float groundDistance;
    bool isOnGround = true; 
    float walkSpeed = 10;
    float jumpHeight = 10;
    public Camera playerCamera;
    Vector3 cameraRotation;


    Animator playerAnimator;
    bool isPlayerWalking = false;

    public GameObject bullet;
    public Transform bulletOrigin;

    private void OnEnable()
    {
        if(instance == null)//singleton
        {
            instance = this;
        }
        playerInput = new PlayerActionMap();//declaring and enabling action map
        playerInput.player.Enable();
    }
    private void OnDisable()
    {
        playerInput.player.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        body = GetComponent<Rigidbody>();//set variables
        playerAnimator = GetComponent<Animator>();

        //assign delegates to action map events
        playerInput.player.movement.performed += cntxt => velocity = cntxt.ReadValue<Vector2>();
        playerInput.player.movement.canceled += cntxt => velocity = Vector2.zero;
        playerInput.player.jump.performed += cntxt => Jump();
        playerInput.player.shooting.performed += cntxt => Shoot();
        //set ground distance
        groundDistance = GetComponent<Collider>().bounds.extents.y;
    }



    public void Shoot()
    {
        //create a new bullet
        Rigidbody bulletRB = Instantiate(bullet,bulletOrigin).GetComponent<Rigidbody>();
        //set its position to infront of the player
        bulletRB.transform.position = bulletOrigin.position + (transform.forward) + (transform.up);
        //add force
        bulletRB.AddForce(((transform.forward*20) + (Vector3.up * 10)),ForceMode.Impulse);
    }

    public void Jump()
    {
        if (isOnGround)
        {
            //add force to body so you can jump
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            isOnGround = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //move character according to velocity
        transform.Translate((Vector3.forward * velocity.y * Time.deltaTime * walkSpeed), Space.Self);//new Vector3(velocity.x,0,velocity.z)
        transform.Translate((Vector3.right * velocity.x * Time.deltaTime * walkSpeed), Space.Self);//new Vector3(velocity.x,0,velocity.z)
        //check if is on ground via raycast
        isOnGround = Physics.Raycast(transform.position, Vector3.up * -1, groundDistance);
        
    }
}
