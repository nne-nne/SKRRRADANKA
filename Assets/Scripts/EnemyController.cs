using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    private Vector2 movementDirection;
    private Slime4Axis slimeScript;
    private bool isFollowing = false;

    private Vector3 directionToPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        slimeScript = GetComponent<Slime4Axis>();
        Sleep();
    }

    public void Notify()
    {
        isFollowing = true;
    }

    public void Sleep()
    {
        isFollowing = false;
    }

    private void FollowPlayer()
    {
        directionToPlayer = player.position - transform.position;
        if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.z))
        {
            if (directionToPlayer.x > 0)
            {
                movementDirection = new Vector2(1, 0);
            }
            else
            {
                movementDirection = new Vector2(-1, 0);
            }
        }
        else
        {
            if (directionToPlayer.z > 0)
            {
                movementDirection = new Vector2(0, 1);
            }
            else
            {
                movementDirection = new Vector2(0, -1);
            }
        }
        Debug.Log(name + "tring to jumpt to " + movementDirection);
        slimeScript.Jump(movementDirection);
    }

    void Update()
    {
        if(isFollowing)
        {
            FollowPlayer();
        }
    }
}
