using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DieScript : MonoBehaviour
{
    public GameObject corpse;
    public Transform SpawnPos;

    bool dead = false;

    TMP_Text livesTxt;
    public int Lives;

    public GameObject DeathParticle;

    public LayerMask noRagdollLayer;
    void Start()
    {

        livesTxt = GameObject.FindWithTag("lives").GetComponent<TMP_Text>();

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Lives > 0f && !Physics2D.OverlapCircle(transform.position,0.3f,noRagdollLayer))
        {
            Die();
        }

        livesTxt.text = Lives.ToString();

    }
    void Die()
    {
        if (Lives > 0f)
        {
            Instantiate(corpse, transform.position, Quaternion.identity);
            transform.position = SpawnPos.position;
            Lives -= 1;
            dead = false;
        }
        else
        {
            Instantiate(DeathParticle,transform.position,Quaternion.identity);
            FindFirstObjectByType<GameManager>().Die();
            FindFirstObjectByType<MouseCam>().enabled = false;
            Destroy(this.gameObject);
        }

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

