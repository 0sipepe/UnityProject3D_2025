using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed, airSpeed = 3f;
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

        controls.Player.Jump.performed += Jump_performed;
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (characterController.isGrounded)
        {
            isJumping = true;
            currentSpeed = airSpeed;
            velocityVertical = Mathf.Sqrt(-jumpHeight * gravity);
        }
    }

    void Update()
    {
        //фигня
        Debug.Log(velocityVertical);
        if (!isJumping)
        {
            
            if (characterController.isGrounded)
            {
                velocityVertical = Mathf.Epsilon * Time.deltaTime;
                currentSpeed = moveSpeed;
            }
        }
        isJumping = false;
        velocityVertical += gravity * Time.deltaTime;
        Vector2 inputMovement = controls.Player.Move.ReadValue<Vector2>();
        Vector3 movementVector = (inputMovement.x * transform.right +  inputMovement.y * transform.forward) + Vector3.up * velocityVertical;

        characterController.Move(currentSpeed * Time.deltaTime * movementVector );
    }
}
