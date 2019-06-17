using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public int id { get; set; }
    public Settings settings { get; set; }
    public List<Character> characters { get; set; }
    public List<Stage> stages { get; set; }

    public Game(int id, Settings settings, List<Character> characters, List<Stage> stages)
    {
        this.id = id;
        this.settings = settings;
        this.characters = characters;
        this.stages = stages;
    }
}
