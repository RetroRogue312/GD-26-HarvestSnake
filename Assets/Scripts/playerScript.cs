using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    private double length;
    public float speed;
    public GameObject tail;
    public List<GameObject> prevPositions = new List<GameObject>();
    public Vector2 tailPos;
    private int direction;
    private int tailDirection;
    //1 = up
    //2 = down
    //3 = left
    //4 = right
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 0;
        tailDirection = 0;
        speed = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        moveHead();
        moveTail();

    }

    void moveHead()
    {
        Vector2 newPos = transform.position;

        if ((Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame) && direction != 2)
        {
            direction = 1;
            prevPositions.Add(Instantiate(tail, newPos, Quaternion.identity));
            
        }

        if ((Keyboard.current.downArrowKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame) && direction != 1)
        {
            direction = 2;
            prevPositions.Add(Instantiate(tail, newPos, Quaternion.identity));
        }

        if ((Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame) && direction != 4)
        {
            direction = 3;
            prevPositions.Add(Instantiate(tail, newPos, Quaternion.identity));
        }
        
        if ((Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame) && direction != 3)
        {
            direction = 4;
            prevPositions.Add(Instantiate(tail, newPos, Quaternion.identity));
        }
        
        if (direction == 1)
        {
            newPos.y = newPos.y + speed * Time.deltaTime;
        }
        
        if (direction == 2)
        {
            newPos.y = newPos.y - speed * Time.deltaTime;
        }

        if (direction == 3)
        {
            newPos.x = newPos.x - speed * Time.deltaTime;
        }
        
        if (direction == 4)
        {
            newPos.x = newPos.x + speed * Time.deltaTime;
        }
        transform.position = newPos;
    }

    void moveTail()
    {
        Vector2 newPos = tail.transform.position;
        Vector2 segPos = prevPositions[0].transform.position;

        if (newPos.y < segPos.y)
        {
            tailDirection = 1;
        }

        if (newPos.y > segPos.y)
        {
            tailDirection = 2;
        }

        if (newPos.x > segPos.x)
        {
            tailDirection = 3;
        }
        else if (newPos.x < segPos.x)
        {
            tailDirection = 4;
        }
        else if (newPos == segPos)
        {
            prevPositions.RemoveAt(0);
        }
        
        
        if (tailDirection == 1)
        {
            newPos.y = newPos.y + speed * Time.deltaTime;
        }
        
        if (tailDirection == 2)
        {
            newPos.y = newPos.y - speed * Time.deltaTime;
        }

        if (tailDirection == 3)
        {
            newPos.x = newPos.x - speed * Time.deltaTime;
        }
        
        if (tailDirection == 4)
        {
            newPos.x = newPos.x + speed * Time.deltaTime;
        }
        tail.transform.position = newPos;
        
    }
}
