using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    private float speed;
    public int direction;
    //1 = up
    //2 = down
    //3 = left
    //4 = right
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        if (direction == 1)
        {
            newPos.y = transform.position.y + speed;
        }
        if ((Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame) && direction != 1)
        {
            direction = 1;
        }

        if ((Keyboard.current.downArrowKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame) && direction != 2)
        {
            direction = 2;
        }

        if ((Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame) && direction != 3)
        {
            direction = 3;
        }
        
        if ((Keyboard.current.rightArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame) && direction != 4)
        {
            direction = 4;
        }
    }
}
