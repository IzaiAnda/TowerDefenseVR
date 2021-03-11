using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadTest : MonoBehaviour
{
    public Text roundT;
    public Text nameT;
    public Text lifeT;
    public Text xT;
    public Text yT;

    public int round;
    public string nombre;
    public int life;
    public int x;
    public int y;
    public int[] position;

    // Start is called before the first frame update
    void Start()
    {
        position = new int[2];
    }

    // Update is called once per frame
    void Update()
    {
        round = int.Parse( roundT.text);
        nombre = nameT.text;
        life = int.Parse(lifeT.text);
        x = int.Parse(xT.text);
        y = int.Parse(yT.text);
        position[0] = x;
        position[1] = y;
    }

    public void Save()
    {
        SaveData.Instance.map.MapSetter(round, nombre, life, position);
        SerializerManager.Save("Save", this);
    }

    public void Load()
    {
        SaveData.Instance = (SaveData)SerializerManager.Load(Application.persistentDataPath + "/saves/Save.save");
    }

}
