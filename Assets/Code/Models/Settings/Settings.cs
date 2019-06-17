using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    public int id { get; set; }
    public bool hints { get; set; }
    public bool sound { get; set; }
    public bool music { get; set; }
    public bool fullscreen { get; set; }

    public Settings(int id, bool hints, bool sound, bool music, bool fullscreen)
    {
        this.id = id;
        this.hints = hints;
        this.sound = sound;
        this.music = music;
        this.fullscreen = fullscreen;
    }
}

