using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject ConnectedBehaviour;


    bool pressed;
    private Animator Anim;

    int pressingObjs = 0;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pressed = pressingObjs != 0;

        if(pressingObjs < 0)
        {
            pressingObjs = 0;
        }
        Anim.SetBool("pressing", pressed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Corpse"))
        {
            pressingObjs++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Corpse"))
        {
            pressingObjs--;
        }
    }
}
