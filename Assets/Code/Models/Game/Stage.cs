using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stage
{
    public int id { get; set; }
    public Boss boss { get; set; }

    public Stage(int id, Boss boss)
    {
        this.id = id;
        this.boss = boss;
    }
}
