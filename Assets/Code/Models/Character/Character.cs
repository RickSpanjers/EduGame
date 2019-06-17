using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public int id { get; set; }
    public int health { get; set; }
    public string name { get; set; }
    public Job job { get; set; }

    public Character()
    {
        // Empty constructor
    }

    public Character(int id, string name, int hp, Job job)
    {
        this.id = id;
        this.health = hp;
        this.name = name;
        this.job = job;
    }
}
