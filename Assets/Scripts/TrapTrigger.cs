using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public float timeToDie = 2f;
    public GameObject slime;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("It's a trap!!!");
            while (timeToDie >= 0f)
            {
                Debug.Log(timeToDie);
                timeToDie -= Time.deltaTime;
            }

            if (timeToDie <= 0f)
            {
                Debug.Log(timeToDie);
                Destroy(slime);
            }
        }
    }
}
