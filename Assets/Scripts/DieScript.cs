using UnityEngine;

public class DieScript : MonoBehaviour
{
    public GameObject corpse;
    public Transform SpawnPos;
    
    void Start()
    {
    


    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(corpse,transform.position,Quaternion.identity);
            transform.position = SpawnPos.position;
        }

    }
}

