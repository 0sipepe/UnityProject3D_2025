using UnityEngine;

public class Rotation : MonoBehaviour
{
   
    [SerializeField] private float rotationSpeed = 100;

   
    private void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * rotationSpeed);
    }
}
