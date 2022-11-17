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
    bool push;
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
        levelText.text = "LEVEL " + (levelNumber + 1);
        EnemiesSpawn.enemiesSpawn.EnemySpawn();
        GameEndSpawn.instance.EnemyCashSpawn();
    }
    private void FixedUpdate()
    {
        if (push)
        {
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * Time.deltaTime * 1500);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 && collision.gameObject.transform.position.z < 125)
        {
            GameOver();
        }
        if (collision.gameObject.layer == 6 && collision.gameObject.transform.position.z > 125)
        {
            Complete();
        }
        if (collision.gameObject.layer == 15)
        {
            push = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 15)
        {
            push = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 14) && other.gameObject.transform.position.z < 125)
        {
            GameOver();
        }
        if ((other.gameObject.layer == 14) && other.gameObject.transform.position.z > 125)
        {
            Complete();
        }
    }
    void Complete()
    {
        nextStage.SetActive(true);
        FirstGunSpawn.first.ProgressBar();
        Destroy(FindObjectOfType<PlayerStateManager>().levelText.gameObject);
        Destroy(FindObjectOfType<PlayerStateManager>().GetComponent<PlayerStateManager>());
        Destroy(FindObjectOfType<GunProperties>().gameObject);
        Collect.collect.isStart = false;
        Collect.collect.EndGame();
        LevelSave();
        GameEndSpawn.instance.endGameBar.gameObject.SetActive(false);
        GameEndSpawn.instance.endGameBarProgress.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Destroy(FindObjectOfType<PlayerStateManager>().levelText.gameObject);
        Destroy(FindObjectOfType<PlayerStateManager>().GetComponent<PlayerStateManager>());
        Destroy(FindObjectOfType<GunProperties>().gameObject);
        Collect.collect.EndGame();
        Collect.collect.isStart = false;
        PlayerPrefs.SetInt("Level", levelNumber);
        levelNumber = PlayerPrefs.GetInt("Level");
        GameEndSpawn.instance.endGameBar.gameObject.SetActive(false);
        GameEndSpawn.instance.endGameBarProgress.gameObject.SetActive(false);
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
        levelText.text = "LEVEL " + (levelNumber + 1);
    }
}
