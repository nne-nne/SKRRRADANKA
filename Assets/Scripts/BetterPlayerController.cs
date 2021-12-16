using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerController : MonoBehaviour
{
    private SlimeMove slimeMove;
    private GridController grid;
    private Animator anim;
    private bool isCrouching = false;

    // Start is called before the first frame update
    void Start()
    {
        slimeMove = GetComponent<SlimeMove>();
        grid = FindObjectOfType<GridController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!slimeMove.isMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                grid.MoveObject(gameObject, Vector2Int.up);
                anim.SetTrigger("jump");
            }
            if (Input.GetKey(KeyCode.A))
            {
                grid.MoveObject(gameObject, Vector2Int.left);
                anim.SetTrigger("jump");
            }
            if (Input.GetKey(KeyCode.S))
            {
                grid.MoveObject(gameObject, Vector2Int.down);
                anim.SetTrigger("jump");
            }
            if (Input.GetKey(KeyCode.D))
            {
                grid.MoveObject(gameObject, Vector2Int.right);
                anim.SetTrigger("jump");
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            anim.SetBool("crouching", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            anim.SetBool("crouching", false);
        }
    }
}
