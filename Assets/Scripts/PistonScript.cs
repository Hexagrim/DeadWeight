using UnityEngine;

public class PistonScript : MonoBehaviour
{
    public bool pushed;
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("pushed", pushed);
    }
}
