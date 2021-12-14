using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Slime4Axis))]
public class PlayerController : MonoBehaviour
{
    private Vector2 movementDirection;
    private Slime4Axis slimeScript;
    
    void Start()
    {
        slimeScript = GetComponent<Slime4Axis>();
    }

    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movementDirection.magnitude > 0)
        {
            slimeScript.Jump(movementDirection);
        }
    }
}
