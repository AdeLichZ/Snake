using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;

    [SerializeField] Text crystalsScore;
    [SerializeField] Text goodFoodScore;

    private int crystals;
    private int goodFood;

    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
        Time.timeScale = 0;
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
        CollisionController.CountingCrystals += CrystalsCount;
        CollisionController.CountingFood += GoodFoodCount;
    }
    private void CrystalsCount()
    {
        gameMenu.GetComponentInChildren<Animation>().Play("CrystalAnimation");
        crystals++;
        crystalsScore.text = crystals.ToString();
    }
    private void GoodFoodCount()
    {
        gameMenu.GetComponentInChildren<Animation>().Play("SkullAnimation");
        
        goodFood++;
        goodFoodScore.text = goodFood.ToString();
    }
    public void LoseCondition()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void WinCondition()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        gameMenu.transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        CollisionController.CountingCrystals -= CrystalsCount;
        CollisionController.CountingFood -= GoodFoodCount;
    }
}
