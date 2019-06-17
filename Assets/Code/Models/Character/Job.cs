using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job
{
    public int id { get; set; }
    public string name { get; set; }

    public Job(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
