using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //Components Global
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private TMP_Text textScore;
    [SerializeField] private Movement movementPlayer;
    [SerializeField] private SpawnSpike spawnSpike;
    //Variables
    private bool gameOver;
    private int score;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Destroy(gameObject);
        panelGameOver.SetActive(gameOver);

        StartCoroutine(IncreaseScore());
    }

    public bool GetGameOver() { return gameOver; }

    public void GameOver()
    {
        spawnSpike.CancelSpawn();
        gameOver = true;
        Time.timeScale = 0;
        score = 0;
        panelGameOver.SetActive(gameOver);
    }

    public void GameReset()
    {
        gameOver = false;
        Time.timeScale = 1;
        panelGameOver.SetActive(gameOver);
        movementPlayer.ResetPosition();

        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject spike in spikes)
        {
            Destroy(spike);
        }
        spawnSpike.SpikeSpawn();
    }

    private IEnumerator IncreaseScore()
    {
        while(!gameOver)
        {
            yield return new WaitForSeconds(1);
            score++;
            textScore.text = score.ToString();
        }
    }

    public void ScoreBySpike() { score += 10; }

    public void BackHome()
    {
        gameOver = false;
        Time.timeScale = 1;
        panelGameOver.SetActive(gameOver);
        movementPlayer.ResetPosition();

        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject spike in spikes)
        {
            Destroy(spike);
        }

        SceneManager.LoadScene("HomeScreen");
    }
}
