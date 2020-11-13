using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { Idle, Playing, Ended, Ready};

public class GameController : MonoBehaviour
{
    public float parallaxSpeed = 0.02f;
    public RawImage background;
    public RawImage platform;
    public GameObject uiIdle;


   
    public GameState gameState = GameState.Idle;

    public GameObject player;
    public GameObject enemyGenerator;

    private AudioSource musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        bool userAction = Input.GetKeyDown("up") || Input.GetMouseButtonDown(0);

        if (gameState == GameState.Idle && (userAction))
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
            player.SendMessage("UpdateState", "PlayerRuning");
            enemyGenerator.SendMessage("StartGenerator");
            musicPlayer.Play();
        }
        else if (gameState == GameState.Playing)
        {
            Parallax();
        }
        else if (gameState == GameState.Ready)
        {
            if (userAction)
            {
                RestartGame();
            }
        }
    }

    void Parallax()
    {
        float finalSped = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSped, 0.0f, 1.0f, 1.0f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSped * 4, 0.0f, 1.0f, 1.0f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
