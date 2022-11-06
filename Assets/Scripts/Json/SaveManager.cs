using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/Resources/JsonData/";
    public static string fileName = "SaveGun.json";

    public static void Save(SaveObject so)
    {
        string dir= Application.dataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }
    public static SaveObject Load()
    {
        string fullPath = Application.dataPath + directory;
        SaveObject so = new SaveObject();

        if (File.Exists(fullPath + fileName))
        {
            string json = File.ReadAllText(fullPath + fileName);
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("sadas");
        }
        return so;
    }
}
