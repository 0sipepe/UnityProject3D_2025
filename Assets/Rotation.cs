using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float sensivity = 100f;
    [SerializeField] private Transform playerTransform;

    private float rotationUpDown = 0;
    Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Player.Enable();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 diretion = controls.Player.Look.ReadValue<Vector2>();

        rotationUpDown -= diretion.y * Time.deltaTime * sensivity;
        rotationUpDown = Mathf.Clamp(rotationUpDown, -90, 90);
        transform.localRotation = Quaternion.Euler(rotationUpDown, 0, 0);


        playerTransform.Rotate(sensivity * Time.deltaTime * diretion.x * Vector3.up);

    }
}

