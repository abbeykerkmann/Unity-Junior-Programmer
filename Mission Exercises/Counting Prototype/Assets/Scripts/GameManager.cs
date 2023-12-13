using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> foods;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;

    private float spawnRate = 5;
    private bool isGameActive = true;
    private int score = 0;
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            GameOver();
        }
    }

    private IEnumerator SpawnFood()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, foods.Count);
            Instantiate(foods[index]);
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives()
    {
        lives--;
        livesText.text = "Lives: " + lives;
    }

    private void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }
}
