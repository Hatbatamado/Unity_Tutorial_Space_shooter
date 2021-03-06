﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    //public Text restatText;
    public Text gameOverText;
    public GameObject restartButton;
    private int score;
    private bool gameOver;
    //private bool restart;

    void Start()
    {
        gameOver = false;
        //restart = false;
        gameOverText.text = "";
        //restatText.text = "";
        restartButton.SetActive(false);
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    //void Update()
    //{
    //    if (restart)
    //    {
    //        if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            Application.LoadLevel(Application.loadedLevel);
    //        }
    //    }
    //}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount && !gameOver; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            if (gameOver)
            {
                restartButton.SetActive(true);
                //restart = true;
                //restatText.text = "Press 'R' for restart";
                break;
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over!";
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
