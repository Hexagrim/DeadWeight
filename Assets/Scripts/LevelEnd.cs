using System.Collections;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public string NextLevel;
    private Animator Anim;
    bool done = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !done)
        {
            StartCoroutine(MoveToPosition(collision.transform, transform.position, 0.25f));
            if(collision.transform.position.x >= transform.position.x)
            {
                collision.transform.localScale = new Vector2(-1f, 1f);
            }
            else
            {
                collision.transform.localScale = new Vector2(1f, 1f);
            }
                Anim.SetTrigger("exit");
            FindFirstObjectByType<GameManager>().Next(NextLevel);
        }
    }
    IEnumerator MoveToPosition(Transform obj, Vector3 targetPos, float duration)
    {
        Vector3 startPos = obj.position;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            obj.position = Vector3.Lerp(startPos, targetPos, time / duration);

            yield return null;
        }

        obj.position = targetPos;
    }
}
