using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DieScript : MonoBehaviour
{
    public GameObject corpse;
    public Transform SpawnPos;

    bool dead = false;
    void Start()
    {
    


    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Die();
        }

    }
    void Die()
    {
        Instantiate(corpse, transform.position, Quaternion.identity);
        transform.position = SpawnPos.position;
        dead = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") && !dead)
        {
            dead = true;
            Die();
        }
    }
}

