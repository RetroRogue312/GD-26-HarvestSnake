using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    private double length;
    public float speed;
    
    private int direction;
    
    public int fruitCount;
    public GameObject[] fruits;
    
    private int countBeforeMapResize;

    public GameObject turnPointPrefab;
    public List<GameObject> turnPoints;
    public bool gameStarted;
    
    
    //1 = up
    //2 = down
    //3 = left
    //4 = right
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 0;
        speed = 1.5f;
        fruitCount = 0;
        gameStarted = false;
        turnPoints = new List<GameObject>();
        turnPoints.Add(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        moveHead();
    }

    void moveHead()
    {
        Vector2 newPos = transform.position;
        if ((Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame) && direction != 2)
        {
            direction = 1;
            gameStarted = true;
            addPoint();
            
        }

        if ((Keyboard.current.downArrowKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame) && direction != 1)
        {
            direction = 2;
            gameStarted = true;
            addPoint();
           
            
        }

        if ((Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame) && direction != 4)
        {
            direction = 3;
            gameStarted = true;
            addPoint();
        }
        
        if ((Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame) && direction != 3)
        {
            direction = 4;
            gameStarted = true;
            addPoint();
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
    }

    void addPoint()
    {
        GameObject point = Instantiate(turnPointPrefab,transform.position,Quaternion.identity);
        turnPoints.Insert(0, point);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fruit"))
        {
            fruitCount += 1;
            print("fruit count: " + fruitCount);
            collision.gameObject.SetActive(false);
            
            
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            speed = 0.0f;
            print("Game over");
        }
        if (collision.gameObject.CompareTag("special"))
        {
            //decrease snake's size.
        }

    }
    
    
}
