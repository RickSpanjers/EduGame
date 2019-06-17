using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InputManager : MonoBehaviour
{
    private Dictionary<string, KeyCode> buttonKeys;

    void OnEnable()
    {
        string path = "keys.edugame";
        if (Save.DoesFileExist(path))
        {
            buttonKeys = Save.LoadKeys();
        }
        else
        {
            buttonKeys = new Dictionary<string, KeyCode>();
            buttonKeys["Jump"] = KeyCode.Space;
            buttonKeys["Attack"] = KeyCode.Return;
        }
    }

    public bool GetButtonDown(string buttonName)
    {

        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            return false;
        }

        return Input.GetKeyDown(buttonKeys[buttonName]);
    }


    public string[] GetButtonNames()
    {
        return buttonKeys.Keys.ToArray();
    }

    public string GetKeyNameForButton(string buttonName)
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            return "N/A";
        }

        return buttonKeys[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keyCode)
    {
        buttonKeys[buttonName] = keyCode;
    }

    public Dictionary<string, KeyCode> getkeys()
    {
        return buttonKeys;
    }
}
