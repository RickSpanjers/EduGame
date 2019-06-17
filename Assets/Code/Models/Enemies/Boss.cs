using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Boss
{
    public int id { get; set; }
    public int hp { get; set; }
    public int damage { get; set; }
    public string name { get; set; }
    public string description { get; set; }

    private Challenge challenge;

    public Boss(int id, int hp, int dmg, String name, String description)
    {
        this.id = id;
        this.hp = hp;
        this.damage = dmg;
        this.name = name;
        this.description = description;
    }

    public void setChallenge(Challenge c)
    {
        challenge = c;
    }

    public Challenge getChallenge()
    {
        return challenge;
    }


}

