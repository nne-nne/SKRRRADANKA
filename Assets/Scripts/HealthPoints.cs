using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public int health = 3;
    public int bulletDamage = 1;
    public float timeToDie;
    public bool diesForAmen = true;
    private bool isDying = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndDeactivate()
    {
        float t = 0;
        while(t < timeToDie)
        {
            t += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }

    public void DealDamage(int dmg)
    {
        health-=dmg;
        if (health <= 0 && !isDying)
        {
            isDying = true;
            animator.SetTrigger("die");
            if(diesForAmen)
            {
                Destroy(this.gameObject, timeToDie);
            }
            else
            {
                StartCoroutine("WaitAndDeactivate");
            }
            
        }
        else if(health > 0)
        {
            Debug.Log("jeszcze nie umieram");
            animator.SetTrigger("receiveDamage");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            DealDamage(bulletDamage);
        }
    }
}
