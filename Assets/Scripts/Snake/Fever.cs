using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    private SnakeMovement snakeMovement;
    private SnakeHandle snakeHandle;
    private CollisionController collisionController;
    [SerializeField] GameObject warningImage;

    private int crystals;
    [SerializeField] float burst;
    void Start()
    {
        snakeMovement = GetComponent<SnakeMovement>();
        snakeHandle = GetComponentInChildren<SnakeHandle>();
        collisionController = GetComponentInChildren<CollisionController>();
        CollisionController.CountingCrystals += FeverCondition;
    }
    void Update()
    {
        
    }
    private void FeverCondition()
    {
        crystals++;
        if(crystals > 3)
        {
            StartCoroutine(FeverTime());
            crystals = 0;
        }
        StopCoroutine(FeverTime());
    }

    private IEnumerator FeverTime()
    {
        snakeHandle.xRange = 0f;
        collisionController.inFever = true;
        snakeMovement.speed *= burst;
        snakeHandle.isControlEnabled = false;
        warningImage.GetComponent<Animation>().Play("FeverWarning");

        yield return new WaitForSeconds(5);
        snakeHandle.isControlEnabled = true;
        snakeMovement.speed /= burst;
        snakeHandle.xRange = 2.7f;
        collisionController.inFever = false;
        yield return new WaitForSeconds(0.1f);
    }
    private void OnDestroy()
    {
        CollisionController.CountingCrystals -= FeverCondition;
    }
}
