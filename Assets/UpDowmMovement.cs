using UnityEngine;

public class UpDowmMovement : MonoBehaviour
{

    [SerializeField] private float speed, distance;
    private float startPos;
    private void Start()
    {
        startPos = transform.position.y;

    }
    private void Update()
    {


        Transform t = transform;
        transform.position = new Vector3(t.position.x, startPos + Mathf.PingPong(Time.time * speed, distance), t.position.z);

    }
}
