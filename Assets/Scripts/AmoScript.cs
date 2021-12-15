using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoScript : MonoBehaviour
{
    public int amoBonus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Shooting shootingScript = other.GetComponent<Shooting>();
            if(shootingScript != null)
            {
                shootingScript.bulletNumer += amoBonus;
                shootingScript.UpdateAmoText();
            }
            Destroy(this.gameObject);
        }
    }
}
