using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonSave : MonoBehaviour
{
    public SaveObject so;
    public int save;
    private void Awake()
    {
        save = PlayerPrefs.GetInt("State");
        if (save == 0)
        {
            save++;
            SaveManager.Save(so);
            PlayerPrefs.SetInt("State", save);
        }
        SceneManager.LoadScene(1);
    }
}
