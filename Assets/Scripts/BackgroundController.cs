using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //Variable
    [SerializeField] private float speed = 0.5f;
    private float length;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        transform.position += speed * Time.fixedDeltaTime * Vector3.left;

        if (transform.position.x < startPos.x - length)
        {
            transform.position = startPos;
        }
    }
}
