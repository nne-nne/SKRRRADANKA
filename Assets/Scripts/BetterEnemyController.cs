using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterEnemyController : MonoBehaviour
{
    public float bangNotifyDistance;

    private Transform player;
    private Vector2Int movementDirection;
    private Vector3 directionToPlayer;
    private SlimeMove slimeMove;
    private GridController grid;
    [SerializeField] private bool isFollowing = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        slimeMove = GetComponent<SlimeMove>();
        grid = FindObjectOfType<GridController>();
    }
    private void OnEnable()
    {
        Shooting.OnShot += TryDistanceNotify;
    }

    private void OnDisable()
    {
        Shooting.OnShot -= TryDistanceNotify;
    }

    public void Notify()
    {
        isFollowing = true;
    }

    public void TryDistanceNotify()
    {
        if (Vector3.Distance(transform.position, player.position) < bangNotifyDistance)
        {
            Notify();
        }
    }

    public void Unnotify()
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
                movementDirection = new Vector2Int(1, 0);
            }
            else
            {
                movementDirection = new Vector2Int(-1, 0);
            }
        }
        else
        {
            if (directionToPlayer.z > 0)
            {
                movementDirection = new Vector2Int(0, 1);
            }
            else
            {
                movementDirection = new Vector2Int(0, -1);
            }
        }
        grid.MoveObject(gameObject, movementDirection);
    }

    void Update()
    {
        if (!slimeMove.isMoving && isFollowing)
        {
            FollowPlayer();
        }
    }
}
