using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private bool isInteractable = true;
    //[SerializeField] private LayerMask layer;

    public UnityEvent onInteract;


    //TODO events, tags layer and other sg\hit
    private void Awake()
    {
        transform.tag = "Interactable";
        //gameObject.layer = 6;
        gameObject.layer = LayerMask.NameToLayer("Interaction");

       
     

    }

    public virtual void Interact()
    {
        onInteract?.Invoke();
    }

    public bool IsIneractable
    {
        get => isInteractable;
        set => isInteractable = value;
    }
 
}
