using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private float interactionDistance = 3;
    [SerializeField] private Image cursor;
    [SerializeField] private float cursorResizeFactor = 1.2f;
    [SerializeField] private LayerMask layerInteracted;

    private Controls controls;
    InteractableObject currentObject;

    Vector3 cursorStartSize;


    private void Start()
    {
        cursorStartSize = cursor.rectTransform.localScale;
        controls = new Controls();
        controls.Player.Enable();

        controls.Player.Interact.performed += Interact_performed; ;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        currentObject?.Interact();
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, interactionDistance, layerInteracted))
        {
            if (hitInfo.transform.CompareTag("Interactable") 
                && hitInfo.transform.TryGetComponent(out InteractableObject io)
                && io.IsIneractable)
            {
                SetInteractableObject(io);
            }
            else
            {
                ResetInteractableObject();
            }
        } 
        else
        {
            ResetInteractableObject();
        }
    }
    private void SetInteractableObject(InteractableObject obj)
    {
        currentObject = obj;
        cursor.color = Color.red;
        cursor.rectTransform.localScale = cursorStartSize * cursorResizeFactor;
    }

    private void ResetInteractableObject()
    {
        currentObject = null;
        cursor.color = Color.white;
        cursor.rectTransform.localScale = cursorStartSize;
    }
}
