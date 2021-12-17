using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiatkaScript : MonoBehaviour
{
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Siup()
    {
        anim.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Siup();
        }
    }
}
