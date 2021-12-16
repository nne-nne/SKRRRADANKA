using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float timeToDie = 1f;
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
        Debug.Log("It's a trap!!!");
        BoxCollider boxcollider = slime.GetComponent<BoxCollider>();
        boxcollider.isTrigger = true;
        StartCoroutine("WaitThenDestroy");
    }

    private IEnumerator WaitThenDestroy()
    {
        float t = 0;
        while (t < timeToDie)
        {
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(slime);
    }
}
