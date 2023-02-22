using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public PlayerInput playerInput;
    private Vector3 playerVelocity;
    Rigidbody rbd;
    private bool groundedPlayer;
    private float playerSpeed = 0f;
    public float acc = 4f;
    public float maxRunSpeed = 5f;
    public float maxWalkSpeed = 1.8f;
    Animator anim;

    public Transform target;

    private InputAction moveAction;
    private InputAction jumpAction;
    public Transform cameraTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        // jumpAction = playerInput.actions["Jump"];
        cameraTransform = Camera.main.transform;
        rbd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement(){
        // Player jump if on ground 
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) //if on ground and negative y velocity
        {
            playerVelocity.y = 0f;    //set y velocity to 0
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0,input.y);
        move = move.x * cameraTransform.right.normalized + move.z*cameraTransform.forward.normalized;
        move.y = 0;
        
        if(move.magnitude!=0){
            // increase playerSpeed until it reach 1.8
            if(playerSpeed<1.8){
                playerSpeed += acc * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.LeftShift) && playerSpeed<maxRunSpeed){
                // increase more 
                playerSpeed += acc * Time.deltaTime;
            }else if(!Input.GetKey(KeyCode.LeftShift) && playerSpeed>maxWalkSpeed){
                playerSpeed -= acc * Time.deltaTime *2;
            }
        }
        if(move.magnitude==0){
            // decrease playerSpeed if greater than 0
            if(playerSpeed>0){
                playerSpeed -= acc * Time.deltaTime;
            }
            
        }

        controller.Move(move * Time.deltaTime * playerSpeed);

        
        // Player look forward rotation
        if(move != Vector3.zero){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move.normalized), 0.1f);
        } 
        
        anim.SetFloat("Velocity",playerSpeed);

        

    }


}