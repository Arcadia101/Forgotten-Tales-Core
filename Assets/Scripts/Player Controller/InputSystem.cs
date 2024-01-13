using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Core Input Actions for Keyboard &Xbox controller.
public class InputSystem : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private Rigidbody rb;
    private Interactor interactor;
    private PlayerInput playerInput;
    private PlayerInputActions actions;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 5f;
    private float walkingSpeed;
    private float sprintSpeed;
    private Vector2 inputVector;
    private Vector2 cameraVector;
    private float cameraRotation;
    private bool On_Jump = false;
    private bool Is_sprinting = false;

    private void Awake()
    {
        SpeedController();
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        interactor = camera.GetComponent<Interactor>();

        actions = new PlayerInputActions();
        actions.Player.Enable();
        actions.Player.Jump.performed += Jump;
        actions.Player.Interact.performed += Interact;
        actions.Player.Crouch.performed += Crouch;
        actions.Player.Reload.performed += Reload;
        actions.Player.Sprint.performed += Sprint;
        actions.Player.SprintEnd.performed += SprintEnd;
        actions.Player.Attack.performed += Attack;
        actions.Player.Aim.performed += Aim;
        actions.Player.Zoom.performed += Zoom;
        actions.Player.Switch.performed += Switch;
        actions.Player.Camera.performed += Camera;
        actions.Player.Menu.performed += Menu;
    }
    
    private void FixedUpdate()
    {
        inputVector = actions.Player.Move.ReadValue<Vector2>();
        cameraVector = actions.Player.Camera.ReadValue<Vector2>();
        cameraRotation += cameraVector.x;
        transform.rotation = Quaternion.Euler(0, cameraRotation, 0); ;
        //camera.transform.rotation.x = cameraVector.y;
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force); //arreglar el movimiento, no mueve adelante, mueve en global
        if (Is_sprinting) 
        {
            speed = sprintSpeed;
        }
        if (!Is_sprinting)
        {
            speed = walkingSpeed;
        }
    }

    private void SpeedController()
    {
        walkingSpeed = speed;
        sprintSpeed = speed * 2;
    }


    //Actions.

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && !On_Jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            On_Jump = true;
        }//Debug.Log("jump");        
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactor.Interact();
            Debug.Log("Interact");
        }//rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Crouch");
        }//rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Reload");
        }//rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Running");
            Is_sprinting = true;
        }
    }

    public void SprintEnd(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            Debug.Log("walking");
            Is_sprinting = false;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack");
        }//rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }

    public void Aim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Aim");
        }//rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Zoom");
        }//rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }

    public void Switch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Switch");
        }//rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }

    public void Camera(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log(cameraVector);
            
        }//rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }

    public void Menu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Menu");
            //Switch by Action.
            //playerInput.SwitchCurrentActionMap("Player");
            //playerInput.SwitchCurrentActionMap("UI");
        }//Debug.Log("jump");        
    }

}
