using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Map
{

    public int round;
    public string nombre;
    public int life;
    public int[] position;

    public void MapSetter()
    {
        this.round = 0;
        this.nombre = "";

        this.position = new int[2];
        this.position[0] = 0;
        this.position[0] = 0;

    }

    public void MapSetter(int round, string nombre, int life, int[] position)
    {
        this.round = round;
        this.nombre = nombre;

        this.position = new int[2];
        this.position[0] = position[0];
        this.position[0] = position[1];

    }
}
