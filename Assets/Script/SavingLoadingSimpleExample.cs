using System.IO;
using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SavingLoadingSimpleExample : MonoBehaviour
{
    [SerializeField] private MapData exampleData = new MapData();

    [ContextMenu("Save")]
    public void Save()
    {
        string json = JsonUtility.ToJson(exampleData);
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText($"{Application.persistentDataPath}/save.save", json);
    }

    [ContextMenu("Load")]

    public void Load()
    {
        if (!File.Exists($"{Application.persistentDataPath}/save.save")) { return;}

        string json = File.ReadAllText($"{Application.persistentDataPath}/save.save");

        exampleData = JsonUtility.FromJson<MapData>(json);
    }

}
