using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serialized]
public class GameData : MonoBehaviour
{
    public bool level1Complete;
    public bool level2Complete;
    public bool level3Complete;
    // public int highScore;

    public bool Level1Complete
    {
        get { return level1Complete; }
        set { level1Complete = value; }
    }

    public bool Level2Complete
    {
        get { return level2Complete; }
        set { level2Complete = value; }
    }

    public bool Level3Complete
    {
        get { return level2Complete; }
        set { level2Complete = value; }
    }

    // public bool highScore
    // {

    // }
}