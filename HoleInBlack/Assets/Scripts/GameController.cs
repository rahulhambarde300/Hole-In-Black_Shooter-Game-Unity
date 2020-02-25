using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hazard;
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;
    private float random;
    public float random2;
    public float randomWait;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    Vector3 spawnPosition;
    Vector3 powerSpawnPosition;

    public Text scoreText;

    private bool gameOver;
    private bool restart;
    private int score;
    private float health;

    private GameOverScript gameOverScript;
    public GameObject player;
    public GameObject PlayerExplosion;
    public GameObject healthUp;
    public GameObject speedUp;

    private HealthBarController healthInstance;
    public GameObject healthBarController;


    void Start() {
        health = 100;
        score = 0;
        updateScore();
        gameOver = false;
        


        GameObject gameControlObject = GameObject.FindWithTag("ui");
        if (gameControlObject != null)
        {
            gameOverScript = gameControlObject.GetComponent<GameOverScript>();
            healthInstance = healthBarController.GetComponent<HealthBarController>();
            healthInstance.setMaxHealth(100.0f);
            healthInstance.setHealth(100.0f);
        }
        if (gameControlObject == null)
            Debug.Log("Sorry ,Couldn't find object");
        StartCoroutine(SpawnWaves());
        StartCoroutine(spawnPowerUps());

        
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            
            for (int i = 0; i < hazardCount; i++)
            {
                if (gameOver)
                    break;
                random = Random.Range(0, 4);
                if (random == 0) {
                    spawnPosition = new Vector3(Random.Range(leftLimit, rightLimit), 0, topLimit);
                }
                else if (random == 1) {
                    spawnPosition = new Vector3(Random.Range(leftLimit, rightLimit), 0, bottomLimit);
                }
                else if (random == 2) {
                    spawnPosition = new Vector3(leftLimit, 0, Random.Range(topLimit, bottomLimit));
                }
                else if (random == 3) {
                    spawnPosition = new Vector3(rightLimit, 0, Random.Range(topLimit, bottomLimit));
                }
                
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

        }
    }

    IEnumerator spawnPowerUps() {
        while (true)
        {
            randomWait = Random.Range(5, 10);
            yield return new WaitForSeconds(randomWait);
            powerSpawnPosition = new Vector3(Random.Range(topLimit, bottomLimit), 0, Random.Range(topLimit, bottomLimit));
            Quaternion spawnRotation = Quaternion.identity;
            random2 = Random.Range(0, 2);
            if(random2 == 0)
                Instantiate(healthUp, powerSpawnPosition, spawnRotation);
            else
                Instantiate(speedUp, powerSpawnPosition, spawnRotation);

        }
    }

    public void addScore(int newScore) {
        score += newScore;
        updateScore();
    }

    void updateScore()
    {
        scoreText.text = "Score:" + score;
    }
    public void decreaseHealth()
    {
        health -= 10;
        updateHealth(health);
        if (health <= 0)
        {
            Instantiate(PlayerExplosion, player.transform.position, player.transform.rotation);
            Destroy(player.gameObject, 0.1f);
            gameOverScript.GameOver();
        }
        
    }
    public void increaseHealth()
    {
        if (health <= 80)
            health += 20;
        else
            health = 100;
        updateHealth(health);
    }
    void updateHealth(float health2)
    {
        healthInstance.setHealth(health2);
    }

}
