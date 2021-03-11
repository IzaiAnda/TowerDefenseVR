using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializerManager 
{
   public static bool Save(string saveName, object saveData)
    {

        BinaryFormatter formatter = GetBinaryformatter();

        if(!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/saves/" + saveName + ".save";

        FileStream file = File.Create(path);

        file.Close();

        return true;
    }

    public static object Load(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryformatter();

        FileStream file = File.Open(path, FileMode.Open);

        try {
            object save = formatter.Deserialize(file);
            file.Close();
            return save;
        }
        catch
        {
            Debug.LogError("Failed to load: " + path);
            file.Close();
            return null;
        }

    }

    private static BinaryFormatter GetBinaryformatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        return formatter;

    }
}
