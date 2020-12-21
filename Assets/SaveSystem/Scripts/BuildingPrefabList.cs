using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct PrefabData
{
    public string id;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "BuildingPrefabList", menuName = "Experiments/BuildingPrefabList", order = 0)]
public class BuildingPrefabList : ScriptableObject
{
    public List<PrefabData> prefabs;

    public GameObject GetByID(string id)
    {
        foreach (var item in this.prefabs)
        {
            if (item.id == id)
            {
                return item.prefab;
            }
        }

        return null;
    }
}