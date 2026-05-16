using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float maxLength = 10f;
    public LayerMask hitMask;


    void Start()
    {
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            transform.up,
            maxLength,
            hitMask
        );

        float length = maxLength;

        if (hit.collider != null)
        {
            length = hit.distance;
        }

        transform.localScale = new Vector3(
            transform.localScale.x,
            length,
            transform.localScale.z
        );
        Debug.DrawRay(transform.position, transform.up * maxLength, Color.red);
    }
}