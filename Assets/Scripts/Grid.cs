using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    private int width, height;
    private float cellSize;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for(int x = 0; x < gridArray.GetLength(0); x++) {
            for(int y = 0; y < gridArray.GetLength(1); y++) {
                CreateWorldText(gridArray[x, y].ToString(), new Vector3(x - 10, y - 5, 0), Color.white, 10);
            }
        }
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize;
    }

    private TextMesh CreateWorldText(string text, Vector3 worldPos, Color color, int fontSize) {
        GameObject go = new GameObject("World_" + worldPos.x + "_" + worldPos.y);
        go.transform.position = worldPos;

        TextMesh textMesh = go.AddComponent<TextMesh>();
        textMesh.text = text;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.color = color;
        textMesh.fontSize = fontSize;
        textMesh.GetComponent<Renderer>().sortingLayerName = "Grid";
        return textMesh;
    }
}
