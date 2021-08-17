using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHandle : MonoBehaviour
{
    public float speed = 50;
    public bool isControlEnabled;
    public float xRange;

    private float ScreenWidth;
    void Start()
    {
        ScreenWidth = Screen.width;
        isControlEnabled = true;
    }

    void Update()
    {
        if (isControlEnabled)
        {
            Handling();
        }
        RangeOfHandling();
    }

    private void Handling()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
        {
            LeftHandle();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RightHandle();
        }
#endif
        int i = 0;
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                RightHandle();
            }
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                LeftHandle();
            }
        }
    }

    private void RangeOfHandling()
    {
        float clampedXPos = Mathf.Clamp(transform.position.x, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    public void LeftHandle()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.left, speed * Time.deltaTime);
    }

    public void RightHandle()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.right, speed * Time.deltaTime);
    }
}
