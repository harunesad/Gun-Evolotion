using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "SaveGun.json";

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }
    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject so = new SaveObject();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            so = JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("sadas");
        }

        // Failsafe: Ensure lists are fully initialized and populated with default values
        if (so == null)
        {
            so = new SaveObject();
        }
        if (so.rangeId == null) so.rangeId = new List<int>();
        if (so.rateFireId == null) so.rateFireId = new List<int>();
        if (so.progressId == null) so.progressId = new List<int>();

        // Pre-fill lists with level 1 up to a safe size of 100 elements
        for (int i = so.rangeId.Count; i < 100; i++) so.rangeId.Add(1);
        for (int i = so.rateFireId.Count; i < 100; i++) so.rateFireId.Add(1);
        for (int i = so.progressId.Count; i < 100; i++) so.progressId.Add(1);
        if (so.cashId <= 0) so.cashId = 1;

        return so;
    }
}
