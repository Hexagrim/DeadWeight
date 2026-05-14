using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator Anim;
    public bool open;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("open", open);
    }
}
