using UnityEngine;
using System.Xml.Serialization;

[System.Serializable]
public class BuildingData
{
    [XmlAttribute]
    public string id;
    [XmlAttribute]
    public float x;
    [XmlAttribute]
    public float y;
    [XmlAttribute]
    public float z;

    public BuildingData()
    {
        this.id = "";

        this.x = 0;
        this.y = 0;
        this.z = 0;
    }

    public BuildingData(string id, Vector3 pos)
    {
        this.id = id;

        this.x = pos.x;
        this.y = pos.y;
        this.z = pos.z;
    }

    public Vector3 GetPosition()
    {
        return new Vector3(x, y, z);
    }
}

public class Building : MonoBehaviour
{
    public string id;

    public BuildingData GenerateData()
    {
        return new BuildingData(this.id, this.transform.position);
    }
}