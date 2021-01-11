using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMaker : MonoBehaviour
{
    public Tile tile;
    public Tilemap tilemap;

    public int mapWidth;
    public int mapHeight;

    private int[,] mapData;

    public CellularData cell;
    public PerlinData perlin;

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    void Start()
    {
        this.mapData = this.cell.GenerateData(this.mapWidth, this.mapHeight);

        this.GenerateTiles();
    }

    void GenerateTiles()
    {
        for (int i = 0; i < this.mapWidth; i++)
        {
            for (int j = 0; j < this.mapHeight; j++)
            {
                if (this.mapData[i, j] == 1)
                {
                    this.tilemap.SetTile(
                        new Vector3Int(i, j, 0),
                        this.tile
                    );
                }
            }
        }
    }

    /// =============================================
    /// <summary>
    ///
    /// </summary>
    void Update()
    {

    }
}
