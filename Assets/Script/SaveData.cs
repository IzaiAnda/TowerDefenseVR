using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{

    public int round;
    public string nombre;
    public int life;
    public int[] position;

    public void Save(int round, string nombre, int life, int[] position)
    {
        this.round = round;
        this.nombre = nombre;

        this.position = new int[3];
        this.position[0] = position[0];
        this.position[0] = position[1];

    }
}
