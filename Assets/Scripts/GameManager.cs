using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator T_Anim;
    bool done = false;
    void Start()
    {
        done = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !done)
        {
            StartCoroutine(LoadScene("MainMenu"));
            done = true;
        }
        if (Input.GetKeyDown(KeyCode.R) && !done)
        {
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
            done = true;
        }
    }

    public void Next(string l)
    {
        if (done) return;
        StartCoroutine(NextLevel(l));
        done = true;
    }
    public void Die()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
        done = true;
    }
    IEnumerator NextLevel(string l)
    {
        T_Anim.SetTrigger("fade");
        FindFirstObjectByType<PlayerMovement>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        FindFirstObjectByType<DieScript>().enabled = false;
        FindFirstObjectByType<PlayerMovement>().Anim.SetBool("isRunning",true);
        FindFirstObjectByType<PlayerMovement>().Anim.SetBool("isJumping", false);
        FindFirstObjectByType<PlayerMovement>().Anim.Play("run");
        FindFirstObjectByType<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(0.411f);
        SceneManager.LoadSceneAsync(l);
    }
    IEnumerator LoadScene(string l)
    {
        T_Anim.SetTrigger("fade");
        FindFirstObjectByType<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(0.411f);
        SceneManager.LoadSceneAsync(l);
    }
}
