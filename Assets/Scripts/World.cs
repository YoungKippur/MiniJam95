using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject LightTile, DarkTile, Spike, Wall, StartPlatform, EndPlatform;
    int width, height;
    string currObject = "EMPTY";
    Game game;
    Grid grid;

    void Start() {
        game = new Game();
        width = 16;
        height = 7;
        generateWorld();
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            grid.SetValue(GetMouseWorldPosition(), DarkTile);
        }

        if(Input.GetMouseButtonDown(1)) {
            Debug.Log(grid.GetValue(GetMouseWorldPosition()));
        }
    }

    public Vector3 GetMouseWorldPosition() {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public Vector3 GetMouseWorldPositionWithZ(Vector3 mousePosition, Camera camera) {
        Vector3 worldPosition = camera.ScreenToWorldPoint(mousePosition);
        return worldPosition;
    }

    public void generateWorld() {
        grid = new Grid(this.LightTile, this.gameObject, this.width, this.height, 1f, new Vector3(-8, -5, 0));
        for(int x = 0; x < this.width; x++) {
            for(int y = 0; y < this.height; y++) {
                if((x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1)) {
                    grid.SetValue(x, y, DarkTile);
                }
            }
        }
        grid.SetValue(1, 3, StartPlatform);
        grid.SetValue(14, 3, EndPlatform);
        grid.SetValue(2, 3, Spike);
    }
}
