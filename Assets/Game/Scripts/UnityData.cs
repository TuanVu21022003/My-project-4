using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityData
{
    public int hp;
    public string name;
    public string description;

    public UnityData()
    {
        hp = 100;
        name = "Tuan Vu";
        description = "Kakaka";
    }

    public UnityData(int hp, string name, string description)
    {
        this.hp = hp;
        this.name = name;
        this.description = description;
    }

    public override string ToString()
    {
        return $"Hp: {hp}, Name: {name}, Description: {description}";
    }
}
