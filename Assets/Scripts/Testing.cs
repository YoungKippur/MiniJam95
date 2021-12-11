using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    Grid grid; 

    void Start() {
        grid = new Grid(gameObject, 10, 5, 2f, new Vector3(5, 5, 0));
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            grid.SetValue(GetMouseWorldPosition(), 56);
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
}
