using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using System.Runtime.Serialization.Formatters.Binary;

public class BuildingManager : MonoBehaviour
{
    public BuildingPrefabList prefabList;

    public Text currentLabel;

    public LayerMask mask;
    public string currentBuildingID;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ! EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100f, this.mask))
            {
                GameObject prefab = this.prefabList.GetByID(this.currentBuildingID);

                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
    }

    public void SetCurrentBuilding(string id)
    {
        this.currentBuildingID = id;
        this.currentLabel.text = id;
    }

    public void Save()
    {
        Building[] buildings = GameObject.FindObjectsOfType<Building>();
        List<BuildingData> data = new List<BuildingData>();

        foreach (var building in buildings)
        {
            data.Add(building.GenerateData());
        }

        var file = new FileStream(
            Application.streamingAssetsPath + "/save.xml",
            FileMode.OpenOrCreate,
            FileAccess.Write
        );
        // Técnicamente borra el archivo.
        file.SetLength(0);

        var formatter = new XmlSerializer(typeof(List<BuildingData>));
        //var formatter = new BinaryFormatter();

        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.streamingAssetsPath + "/save.xml"))
        {
            var file = new FileStream(Application.streamingAssetsPath + "/save.xml", FileMode.Open, FileAccess.Read);

            var formatter = new XmlSerializer(typeof(List<BuildingData>));
            //var formatter = new BinaryFormatter();

            var data = formatter.Deserialize(file) as List<BuildingData>;

            foreach (var bData in data)
            {
                var prefab = prefabList.GetByID(bData.id);

                Instantiate(prefab, bData.GetPosition(), Quaternion.identity);
            }

            file.Close();
        }
    }
}
