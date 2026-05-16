using UnityEngine;
using UnityEngine.Rendering;

public class WaterTriggerHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _waterMask;
    [SerializeField] private GameObject _splashParticles;

    private EdgeCollider2D _edgeColl;
    private InteractableWater _water;
    private void Awake()
    {
        _edgeColl = GetComponent<EdgeCollider2D>();
        _water = GetComponent<InteractableWater>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((_waterMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if(rb != null)
            {
                Vector2 localPos = gameObject.transform.localPosition;
                Vector2 hitOjectPos = collision.transform.position;
                Bounds hitObjectBounds = collision.bounds;

                Vector3 spawnPos = Vector3.zero;
                if (collision.transform.position.y >= _edgeColl.points[1].y + _edgeColl.offset.y + localPos.y)
                {
                    spawnPos = hitOjectPos/2 - new Vector2(0f, hitObjectBounds.extents.y);
                }
                else
                {
                    spawnPos = hitOjectPos/2 + new Vector2(0f, hitObjectBounds.extents.y);
                }

                //Instantiate(_splashParticles, spawnPos, Quaternion.identity);

                int multiplier = 1;

                if (rb.linearVelocityY < 0f)
                {
                    multiplier = -1;
                }
                else
                {
                    multiplier = 1;
                }

                float vel = rb.linearVelocityY * _water.ForceMultiplider;
                vel = Mathf.Clamp(Mathf.Abs(vel), 0f, _water.MaxForce);
                vel *= multiplier;

                _water.Splash(collision, vel);
            }
        }
    }
}
