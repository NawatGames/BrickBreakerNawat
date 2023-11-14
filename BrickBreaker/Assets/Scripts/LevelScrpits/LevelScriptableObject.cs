using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level/Level", order = 1)]
public class LevelScriptableObject: ScriptableObject
{
    public int levelNumber;
    public LevelRowScriptableObject[] levelRows;
}