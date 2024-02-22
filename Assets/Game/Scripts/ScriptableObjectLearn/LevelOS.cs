using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
public class LevelOS : ScriptableObject
{ 
      public List<LevelItemData> list = new List<LevelItemData>();
}
