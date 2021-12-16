using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Vector2Int size;
    private GameObject[,] grid;
    public List<GameObject> traps;
    public static float tileWidth = 1f;
    public float slimeMovementTime;

    public GameObject player;

    void Awake()
    {
        grid = new GameObject[size.x,size.y];
    }

    private void PrintGrid()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (grid[i, j] != null)
                {
                    Debug.Log(grid[i, j].name + ": " + i + "," + j);
                }
            }
        }
    }
    void Update()
    {
       
    }

    public void PlaceObject(GameObject gameObject, Vector2Int position)
    {
        if(grid[position.x, position.y] == null)
        {
            grid[position.x, position.y] = gameObject;
        }
        else
        {
            Debug.Log("there is already an object");
        }
    }

    private Vector2Int FindOnGrid(GameObject gameObject)
    {
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                if(grid[i,j]==gameObject)
                {
                    return new Vector2Int(i, j);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    public void MoveObject(GameObject gameObject, Vector2Int direction)
    {
        Vector2Int originalPos = FindOnGrid(gameObject);
        Vector2Int targetPos = originalPos + direction;
        GameObject occupant = grid[targetPos.x, targetPos.y];
        if(occupant == null)
        {
            SlimeMove slimeScript = gameObject.GetComponent<SlimeMove>();
            if(slimeScript != null)
            {
                if(!slimeScript.isMoving)
                {
                    slimeScript.Rotate(direction);
                    IEnumerator movementCoroutine = MovementCoroutine(gameObject, originalPos, targetPos);
                    StartCoroutine(movementCoroutine);
                }
            }
        }
    }

    private Vector3 GetFieldCentre(Vector2Int field)
    {
        return new Vector3(field.x * tileWidth, 0f, field.y * tileWidth);
    }

    private IEnumerator MovementCoroutine(GameObject slime, Vector2Int originalField, Vector2Int targetField)
    {
        SlimeMove slimeScript = slime.GetComponent<SlimeMove>();
        if(slimeScript != null)
        {
            slimeScript.isMoving = true;
            Vector3 originalPos = slime.transform.position;
            Vector3 targetPos = GetFieldCentre(targetField);
            float t = 0;
            grid[targetField.x, targetField.y] = slime;
            while (t < slimeMovementTime / 2)
            {
                t += Time.deltaTime;
                slime.transform.position = Vector3.Lerp(originalPos, targetPos, t / slimeMovementTime);
                yield return null;
            }
            grid[originalField.x, originalField.y] = null;
            while (t < slimeMovementTime)
            {
                t += Time.deltaTime;
                slime.transform.position = Vector3.Lerp(originalPos, targetPos, t / slimeMovementTime);
                yield return null;
            }
            slimeScript.isMoving = false;
        }
    }
}
