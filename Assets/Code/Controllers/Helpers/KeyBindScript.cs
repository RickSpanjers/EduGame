using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour
{
    public Text attack, left, right, jump;

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    void Start()
    {
        keys.Add("Attack", KeyCode.Return);
        keys.Add("Jump", KeyCode.Space);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);

        attack.text = keys["Attack"].ToString();
        jump.text = keys["Jump"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
    }
}
