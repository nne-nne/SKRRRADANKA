using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerController : MonoBehaviour
{
    private SlimeMove slimeMove;
    private GridController grid;
    // Start is called before the first frame update
    void Start()
    {
        slimeMove = GetComponent<SlimeMove>();
        grid = FindObjectOfType<GridController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!slimeMove.isMoving)
        {
            if (Input.GetKey(KeyCode.W))
            {
                grid.MoveObject(gameObject, Vector2Int.up);
            }
            if (Input.GetKey(KeyCode.A))
            {
                grid.MoveObject(gameObject, Vector2Int.left);
            }
            if (Input.GetKey(KeyCode.S))
            {
                grid.MoveObject(gameObject, Vector2Int.down);
            }
            if (Input.GetKey(KeyCode.D))
            {
                grid.MoveObject(gameObject, Vector2Int.right);
            }
        }
    }
}
