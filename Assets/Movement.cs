using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed, airSpeed = 1f;
    [SerializeField] private float gravity = -10;
    [SerializeField] private float jumpHeight;


    private Controls controls;

    private float currentSpeed;
    private float velocityVertical = -1;
    private bool isJumping;


    void Start()
    {
        controls = new Controls();
        controls.Player.Enable();

        currentSpeed = moveSpeed;

        controls.Player.Jump.performed += Jump_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("jump performed");
        if (characterController.isGrounded)
        { 
            velocityVertical = Mathf.Sqrt(-jumpHeight * gravity);
            isJumping = true;
            currentSpeed = airSpeed;
           
        }
    }

    private void Update()
    {
       
        
        if (!isJumping)
        {
            if (characterController.isGrounded)
            {
                velocityVertical = -Mathf.Epsilon;
                currentSpeed = moveSpeed;
            }
        }

        isJumping = false;
      
        Vector2 inputMovement = controls.Player.Move.ReadValue<Vector2>();

        velocityVertical += gravity * Time.deltaTime;
        //Debug.Log($"input vector {inputMovement.x}  and {inputMovement.y}"  );

        Vector3 movementVector = (inputMovement.x * transform.right +  inputMovement.y * transform.forward) * currentSpeed + transform.up * velocityVertical;


        characterController.Move(Time.deltaTime * movementVector);
    }
}
