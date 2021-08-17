using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private SnakeTail snake;

    public bool inFever;
    public static event Action CountingCrystals;
    public static event Action CountingFood;
    private void Start()
    {
        inFever = false;
        Time.timeScale = 1;
        snake = GetComponent<SnakeTail>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.name);
        if(collision.tag == "crystal")
        {
            Destroy(collision.gameObject);
            CountingCrystals();
        }

        if(collision.tag == "goodfood")
        {
            CountingFood();
            snake.AddCircle();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "badfood")
        {
            if (!inFever)
            {
                GameManager.singleton.LoseCondition();
            }
            if (inFever)
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.tag == "Finish")
        {
            GameManager.singleton.WinCondition();
        }

        if (collision.tag == "BlueCheckPoint")
        {
            snake.ChangeColor(Color.blue);
        }
        if (collision.tag == "YellowCheckPoint")
        {
            snake.ChangeColor(Color.yellow);
        }
        if (collision.tag == "GreenCheckPoint")
        {
            snake.ChangeColor(Color.green);
        }
        if (collision.tag == "PurpleCheckPoint")
        {
            snake.ChangeColor(Color.magenta);
        }
        if (collision.tag == "RedCheckPoint")
        {
            snake.ChangeColor(Color.red);
        }
        if (collision.tag == "OrangeCheckPoint")
        {
            Color myColor = new Color32(255, 127, 0, 255);
            snake.ChangeColor(myColor);
        }
        if (collision.tag == "TurquiseCheckPoint")
        {
            var myColor = new Color32(0, 255, 175,255);
            snake.ChangeColor(myColor);
        }
    }

}
