using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public bool isGameActive;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public GameObject instructionsScreen;

    private float spawnRate = 1.0f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToTitle()
    {
        instructionsScreen.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }

    public void ShowInstructions()
    {
        titleScreen.gameObject.SetActive(false);
        instructionsScreen.gameObject.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }
}
