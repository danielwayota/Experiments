using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

public class Navigator : MonoBehaviour
{
    public Tilemap map;

    private int[,] distanceMap;
    private List<Vector3> path;

    void Start()
    {
        this.path = new List<Vector3>();
        this.distanceMap = new int[this.map.size.x, this.map.size.y];

        var min = this.map.localBounds.min;
        for (int x = 0; x < this.map.size.x; x++)
        {
            for (int y = 0; y < this.map.size.y; y++)
            {
                // Obtenemos el Tile en esta posición
                int mapX = (int)(x + min.x);
                int mapY = (int)(y + min.y);

                var tile = this.map.GetTile(new Vector3Int(mapX, mapY, 0));

                // Asignamos el valor de "onda"
                if (tile != null)
                {
                    this.distanceMap[x,y] = -1;
                }
                else
                {
                    this.distanceMap[x,y] = 0;
                }
            }
        }
    }

    Vector3Int ToLocal(Vector3 world)
    {
        var local = (world - this.map.transform.position) - this.map.localBounds.min;

        return new Vector3Int((int)local.x, (int)local.y, 0);
    }

    Vector3 ToGlobal(Vector3Int local)
    {
        var f_local = new Vector3(local.x, local.y, 0);

        return f_local + this.transform.position + this.map.localBounds.min;
    }

    Vector3 ToGlobal(Vector3 local)
    {
        return local + this.transform.position + this.map.localBounds.min;
    }

    private void GetPathUsingLocalCoordinates(Vector3Int localStart, Vector3Int localTarget)
    {
        // Clear map
        for (int x = 0; x < this.map.size.x; x++)
        {
            for (int y = 0; y < this.map.size.y; y++)
            {
                if (this.distanceMap[x, y] != -1)
                    this.distanceMap[x, y] = 0;
            }
        }

        this.path.Clear();

        if (this.distanceMap[localTarget.x, localTarget.y] != 0 || this.distanceMap[localStart.x, localStart.y] != 0)
        {
            // Sin solución
            return;
        }

        int distance = 1;

        Queue<Vector3Int> visitedCells = new Queue<Vector3Int>();
        this.distanceMap[localTarget.x, localTarget.y] = distance;
        visitedCells.Enqueue(localTarget);

        while (visitedCells.Count != 0 && visitedCells.Count < 1000)
        {
            distance += 1;

            var cell = visitedCells.Dequeue();
            this.Visit(visitedCells, distance, cell.x, cell.y + 1); // UP
            this.Visit(visitedCells, distance, cell.x, cell.y - 1); // Down
            this.Visit(visitedCells, distance, cell.x + 1, cell.y); // Right
            this.Visit(visitedCells, distance, cell.x - 1, cell.y); // Left
        }
    }

    private void ComputePath(Vector3Int localStart)
    {
        Vector3Int currentLocalTile = localStart;

        bool working = true;
        while (working)
        {
            path.Add(this.ToGlobal(currentLocalTile));

            var (x, y) = ((int)currentLocalTile.x, (int)currentLocalTile.y);
            var d = this.distanceMap[x, y];

            working = false;
            if (this.distanceMap[x, y + 1] < d && this.distanceMap[x, y + 1] != -1)
            {
                currentLocalTile.Set(x, y + 1, 0);
                working = true;
                continue;
            }
            if (this.distanceMap[x, y - 1] < d && this.distanceMap[x, y - 1] != -1)
            {
                currentLocalTile.Set(x, y - 1, 0);
                working = true;
                continue;
            }
            if (this.distanceMap[x + 1, y] < d && this.distanceMap[x + 1, y] != -1)
            {
                currentLocalTile.Set(x + 1, y, 0);
                working = true;
                continue;
            }
            if (this.distanceMap[x - 1, y] < d && this.distanceMap[x - 1, y] != -1)
            {
                currentLocalTile.Set(x - 1, y, 0);
                working = true;
                continue;
            }
        }
    }

    private void Visit(Queue<Vector3Int> visitedCells, int distance, int x, int y)
    {
        if (x < 0 || x >= this.map.size.x)
            return;

        if (y < 0 || y >= this.map.size.y)
            return;

        if (this.distanceMap[x, y] == 0)
        {
            this.distanceMap[x, y] = distance;
            visitedCells.Enqueue(new Vector3Int(x, y, 0));
        }
    }

    public List<Vector3> GetPath(Vector3 start, Vector3 end)
    {
        var lStart = this.ToLocal(start);
        var lEnd = this.ToLocal(end);

        this.GetPathUsingLocalCoordinates(lStart, lEnd);
        this.ComputePath(lStart);

        // Mueve a la mitad del Tile
        for (int i = 0; i < this.path.Count; i++)
        {
            var loc = this.path[i] + Vector3.one * 0.5f;
            loc.z = 0;

            this.path[i] = loc;
        }

        return this.path;
    }
}
