using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime4Axis : MonoBehaviour
{
    [SerializeField] private float rotationTime;
    [SerializeField] private float movementTime;
    [Tooltip("Frac 0-1")]

    public Transform checkPivot;
    private Rigidbody rb;
    private Vector3 lookDirection;
    private bool isRotating = false, isMoving = false;

    private static float tileWidth = 2f;
    private Collider col;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void Update()
    {

    }

    public void Jump(Vector2 direction)
    {
        if (!isRotating && !isMoving)
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
            IEnumerator move = Move(direction);
            StartCoroutine(move);
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

        //rb.AddForce(transform.forward * moveForce, ForceMode.Impulse);
    }



    private IEnumerator Move(Vector2 direction)
    {
        float t = 0;
        while (t < rotationTime)
        {
            t += Time.deltaTime;
            yield return null;
        }
        col.bounds.center.Set(0f, 0.5f, 2f);


        RaycastHit hit;
        if (!Physics.Raycast(checkPivot.position, transform.forward, out hit, tileWidth) ||
            hit.collider.gameObject.layer != LayerMask.NameToLayer("nonwalkable"))
        {
            t = 0;
            isMoving = true;
            Vector3 originalPosition = transform.position;
            Vector3 targetPosition = new Vector3(originalPosition.x + direction.x * tileWidth,
                                                     0f,
                                                  originalPosition.z + direction.y * tileWidth);

            while (t < movementTime)
            {
                rb.position = Vector3.Lerp(transform.position, targetPosition, t / movementTime);
                col.bounds.center.Set(0f, 0.5f, 2-2*t/movementTime);
                t += Time.deltaTime;
                yield return null;
            }
            isMoving = false;
            col.bounds.center.Set(0f, 0.5f, 0f);

        }
    }
}
