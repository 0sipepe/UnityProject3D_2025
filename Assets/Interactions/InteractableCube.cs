using UnityEngine;

public class InteractableCube:  InteractableObject
{
    public override void Interact()
    {
        base.Interact();

        GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
}
