using UnityEngine;

public class MouseExplosion : MonoBehaviour
{
    public Camera cam;
    public GameObject particle;

    public float radius = 5f;
    public float force = 10f;
    public float cooldown = 0.35f;

    float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && timer <= 0)
        {
            timer = cooldown;

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -cam.transform.position.z;

            Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);
            worldPos.z = 0f;

            Instantiate(particle, worldPos, Quaternion.identity);

            Collider2D[] hits = Physics2D.OverlapCircleAll(worldPos, radius);

            foreach (Collider2D hit in hits)
            {
                Rigidbody2D rb = hit.attachedRigidbody;

                if (rb != null && hit.CompareTag("Corpse"))
                {
                    Vector2 dir = rb.position - (Vector2)worldPos;

                    float distance = dir.magnitude;
                    float power = 1 - (distance / radius);

                    if (power < 0)
                    {
                        power = 0;
                    }

                    dir.Normalize();

                    rb.AddForce((dir + Vector2.up * 0.3f) * force * power, ForceMode2D.Impulse);

                    HingeJoint2D hinge = hit.GetComponent<HingeJoint2D>();

                    if (hinge != null)
                    {
                        Destroy(hinge);
                    }
                }
            }
        }
    }

}