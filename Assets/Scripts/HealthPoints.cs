using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public GameObject bullet;
    public int health = 3;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (animator != null)
            {
                animator.SetTrigger("receiveDamage");
            }

            health--;
            if (health < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
