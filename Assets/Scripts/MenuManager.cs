using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Animator T_Anim;
    public Button[] buttons;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int unlocked = PlayerPrefs.GetInt("maxLevel", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = i < unlocked;
        }
    }

    public void PlayLevel(string l)
    {
        StartCoroutine(LoadLevel(l));
    }

    IEnumerator LoadLevel(string l)
    {
        T_Anim.SetTrigger("fade");
        yield return new WaitForSeconds(0.41f);
        SceneManager.LoadSceneAsync(l);
    }
}
