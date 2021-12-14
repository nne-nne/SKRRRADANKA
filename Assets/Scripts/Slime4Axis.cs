using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime4Axis : MonoBehaviour
{
    [SerializeField] private float rotationTime;
    [SerializeField] private float moveForce;
    [SerializeField] private float moveCooldown;
    private Rigidbody rb;
    private Vector2 movementDirection;
    private Vector3 lookDirection;
    private bool isRotating = false, isMoving = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    public void Jump(Vector2 direction)
    {
        if(!isRotating && !isMoving)
        {
            if (direction.x > 0)
            {
                lookDirection = new Vector3(0, 90, 0);
            }
            else if (direction.y > 0)
            {
                lookDirection = new Vector3(0, 0, 0);
            }
            else if (direction.x < 0)
            {
                lookDirection = new Vector3(0, -90, 0);
            }
            else if (direction.y < 0)
            {
                lookDirection = new Vector3(0, 180, 0);
            }

            StopAllCoroutines();
            IEnumerator rotate = RotateTowards(Quaternion.Euler(lookDirection));
            StartCoroutine(rotate);
        }
    }

    private IEnumerator RotateTowards(Quaternion targetRotation)
    {
        Quaternion originalRotation = transform.rotation;
        float t = 0;
        isRotating = true;
        while (t < rotationTime)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(originalRotation, targetRotation, t / rotationTime);
            yield return null;
        }
        isRotating = false;

        rb.AddForce(transform.forward * moveForce, ForceMode.Impulse);
        StartCoroutine("MoveCooldown");
    }

    private IEnumerator MoveCooldown()
    {
        isMoving = true;
        float t = 0;
        while (t < moveCooldown)
        {
            t += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
    }
}
