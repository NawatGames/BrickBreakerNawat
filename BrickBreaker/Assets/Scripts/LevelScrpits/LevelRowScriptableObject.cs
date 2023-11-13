using UnityEngine;

[CreateAssetMenu(fileName = "Row", menuName = "ScriptableObjects/Level/Row", order = 1)]
public class LevelRowScriptableObject: ScriptableObject
{
    public int turnCount;
    public GameObject[] rowObjects;
}
