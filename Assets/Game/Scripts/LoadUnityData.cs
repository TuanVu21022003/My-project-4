using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUnityData : MonoBehaviour
{
    [ContextMenu("Load")]
    public UnityData LoadData()
    {
        string dataJson = PlayerPrefs.GetString(KeyConstant.KEY_SAVEUNITYDATA);
        if(string.IsNullOrEmpty(dataJson))
        {
            return new UnityData();
        }
        return JsonUtility.FromJson<UnityData>(dataJson);
    }

    public void SaveUnitData(UnityData data)
    {
        string dataString = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(KeyConstant.KEY_SAVEUNITYDATA, dataString);
    }
    [ContextMenu("Save")]
    public void SaveData()
    {
        UnityData data = new UnityData(200, "Nam", "MEMEMEE");
        SaveUnitData(data);
    }
}
