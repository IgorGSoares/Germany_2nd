using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string DataFolder()
    {
        #if UNITY_EDITOR
            return Application.streamingAssetsPath;
        #else
            return Application.persistentDataPath;
        #endif
    }

    public static void SaveGame(int coins, bool[] boughtSkins, string equippedSkin)
    {
        GameData data = new GameData(coins, boughtSkins, equippedSkin);
        string json = JsonUtility.ToJson(data, true);

        if(!Directory.Exists(DataFolder())) Directory.CreateDirectory(DataFolder());
        File.WriteAllText(DataFolder() + "/iceSave.json", json);

        #if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
        #endif
    }

    public static void ClearGame()
    {
        if(Directory.Exists(DataFolder()) && File.Exists(DataFolder() + "/iceSave.json"))
        {
            File.Delete(DataFolder() + "/iceSave.json");
        }
        
        #if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
        #endif
    }

    public static bool HasSaveFile() => Directory.Exists(DataFolder()) && File.Exists(DataFolder() + "/iceSave.json");

    public static void CheckVersionOfFile()
    {
        GameData tempData = LoadGame();

        if(tempData.version != Application.version || tempData.version == null) ClearGame();
    }


    public static GameData LoadGame()
    {
        if(!Directory.Exists(DataFolder())) return null;
        else if(File.Exists(DataFolder() + "/iceSave.json"))
        {
            Debug.Log(Application.persistentDataPath);
            string json = File.ReadAllText(DataFolder() + "/iceSave.json");

            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }
        else return null;
    }
}
