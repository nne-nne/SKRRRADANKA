using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilczydolScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pianka;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthPoints hp = other.GetComponent<HealthPoints>();
        pianka.SetActive(false);
        if (hp != null)
        {
            hp.grid.RemoveFromGrid(other.gameObject);
            Destroy(other.gameObject.GetComponent<SlimeMove>());
            Rigidbody rb = hp.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
            hp.DealDamage(int.MaxValue, Vector3.up);
        }
    }
}
