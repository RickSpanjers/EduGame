using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string image { get; set; }
    public string sound { get; set; }

    public Enemy(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
