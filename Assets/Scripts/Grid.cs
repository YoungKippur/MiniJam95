using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    private GameObject tilePrefab;
    private GameObject parent;
    private Vector3 originPosition;
    private int width, height;
    private float cellSize;
    private GameObject[,] gridArray;

    public Grid(GameObject tilePrefab, GameObject parent, int width, int height, float cellSize, Vector3 originPosition = new Vector3()) {
        this.tilePrefab = tilePrefab;
        this.parent = parent;
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new GameObject[width, height];

        for(int x = 0; x < gridArray.GetLength(0); x++) {
            for(int y = 0; y < gridArray.GetLength(1); y++) {
                gridArray[x, y] = CreateWorldObject(tilePrefab, GetWorldPosition(x, y));

                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100000);
                Debug.DrawLine(GetWorldPosition(x + 1, y), GetWorldPosition(x, y), Color.white, 100000);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100000);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100000);
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * this.cellSize + this.originPosition;
    }

    public GameObject CreateWorldObject(GameObject prefab, Vector3 position) {
        GameObject worldObject = GameObject.Instantiate(prefab) as GameObject;
        worldObject.transform.parent = this.parent.transform;
        worldObject.name = prefab.name;
        worldObject.transform.localScale = Vector3.one * this.cellSize;
        worldObject.transform.position = position + Vector3.one * this.cellSize * 0.5f;
        switch(worldObject.tag) {
            case "Wall":
                worldObject.transform.localScale *= 3f;
                worldObject.transform.position += Vector3.up * this.cellSize * 0.2f;
                break;
            case "Spikes":
                worldObject.transform.localScale *= 3f;
                break;
            case "Start":
                worldObject.transform.localScale *= 3f;
                break;
            case "End":
                worldObject.transform.localScale *= 3f;
                break;
        }
        return worldObject;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize);
    }

    public void SetValue(int x, int y, GameObject value) {
        if(x < 0 || x >= width || y < 0 || y >= height) return;
        if(gridArray[x, y] != null) GameObject.Destroy(gridArray[x, y]);
        gridArray[x, y] = CreateWorldObject(value, GetWorldPosition(x, y));
    }

    public void SetValue(Vector3 worldPosition, GameObject value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public GameObject GetValue(int x, int y) {
        if(x < 0 || x >= width || y < 0 || y >= height) return null;
        return gridArray[x, y];
    }

    public GameObject GetValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
