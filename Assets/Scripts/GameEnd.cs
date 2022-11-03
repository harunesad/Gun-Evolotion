using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public static GameEnd end;
    public GameObject gameOver, nextStage;
    public TextMeshProUGUI levelText;
    public int levelNumber;
    private void Awake()
    {
        end = this;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            levelNumber = PlayerPrefs.GetInt("Level");
        }
        levelText.text = "" + (levelNumber + 1);
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 && collision.gameObject.transform.position.z < 2)
        {
            Debug.Log(collision.gameObject.name);
            GameOver();
        }
        if (collision.gameObject.layer == 6 && collision.gameObject.transform.position.z > 2)
        {
            Complete();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 14) && other.gameObject.transform.position.z < 2)
        {
            Debug.Log(other.gameObject.name);
            GameOver();
        }
        if ((other.gameObject.layer == 14) && other.gameObject.transform.position.z > 2)
        {
            Complete();
        }
    }
    void Complete()
    {
        nextStage.SetActive(true);
        FirstGunSpawn.first.ProgressBar();
        //stateManager.CancelInvoke();
        Destroy(FindObjectOfType<PlayerStateManager>().GetComponent<PlayerStateManager>());
        Destroy(FindObjectOfType<SpawnPlayerBullet>().GetComponent<SpawnPlayerBullet>());
        Collect.collect.isStart = false;
        Collect.collect.EndGame();
        LevelSave();
    }

    public void GameOver()
    {
        //EnemyStateManager enemyState = collision.transform.Find("SpawnPoint").GetComponent<EnemyStateManager>();
        gameOver.SetActive(true);
        //stateManager.CancelInvoke();
        Destroy(FindObjectOfType<PlayerStateManager>().GetComponent<PlayerStateManager>());
        Destroy(FindObjectOfType<SpawnPlayerBullet>().GetComponent<SpawnPlayerBullet>());
        Collect.collect.EndGame();
        //Destroy(enemyState.gameObject);
        Collect.collect.isStart = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelText();
    }
    public void LevelSave()
    {
        levelNumber++;
        PlayerPrefs.SetInt("Level", levelNumber);
        levelNumber = PlayerPrefs.GetInt("Level");
    }
    void LevelText()
    {
        levelText.text = "" + (levelNumber + 1);
    }
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
