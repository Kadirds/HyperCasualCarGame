using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    
    public GameObject StartP, InGameP, NextP, GameOverP;
    public float countDown = 1F;

    [SerializeField] private int asynSceneIndex = 1;

    public enum GameState{
        
        Start,
        Ingame,
        Next,
        Gameover


    }
    public GameState gameState;
    public enum Panels
    {
        Startp,
        Ingamep,
        Nextp,
        Gameoverp,
    }
    private void Start()
    {
        gameState = GameState.Start;
    }
    private void Update()
    {

       
        switch (gameState)
        {
            case GameState.Start: GameStart();
                break;

            case GameState.Ingame: GameInGame();
                break;

            case GameState.Next: GameFinish();
                break;

            case GameState.Gameover: GameOver(); 
                break;
        }
        
    }

    void PanelController(Panels currentPanel)
    {
        StartP.SetActive(false);
        InGameP.SetActive(false);
        NextP.SetActive(false);
        GameOverP.SetActive(false);

        switch (currentPanel)
        {
            case Panels.Startp:
                StartP.SetActive(true);
                break;
            case Panels.Ingamep:
                InGameP.SetActive(true);
                break;
            case Panels.Nextp:
                NextP.SetActive(true);
                break;
            case Panels.Gameoverp:
                GameOverP.SetActive(true);
                break;
            
        }
    }

    void GameStart()
    {
        PanelController(Panels.Startp);
        if (Input.anyKeyDown)
        {
            gameState = GameState.Ingame;
        }
        
        if (SceneManager.sceneCount < 2)
        {
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        }

    }
    void GameInGame()
    {
        PanelController(Panels.Ingamep);
    }
    void GameFinish()
    {
        PanelController(Panels.Nextp);
    }
    void GameOver()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0)
           PanelController(Panels.Gameoverp);
        
        
    }

    public void RestartButton()
    {
        SceneManager.UnloadSceneAsync(asynSceneIndex);
        gameState = GameState.Start;
    }

    public void NextLevelButton()
    {
        if (SceneManager.sceneCountInBuildSettings == asynSceneIndex + 1)
        {
            SceneManager.UnloadSceneAsync(asynSceneIndex);
            asynSceneIndex = 1;
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        }
        else
        {
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(asynSceneIndex);
                asynSceneIndex++;
            }
            SceneManager.LoadSceneAsync(asynSceneIndex, LoadSceneMode.Additive);
        }
        gameState = GameState.Start;
    }
}
