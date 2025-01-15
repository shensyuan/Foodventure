using UnityEngine;
using System.Collections.Generic;
using System;
using DoorScript;

public class DoorInteraction : MonoBehaviour {

    [SerializeField] int doorId; // 門的編號
    [SerializeField] float openSpeed = 20f;
    private AnimalController animalController;
    private Door door;
    private bool doorIsOpened = false;

#nullable enable
    private Action? callback = null;

    // 定義門到門的固定傳送規則
    private Dictionary<int, int> doorPaths = new Dictionary<int, int>
    {
        { 8, 3 },
        { 6, 4 },
        { 7, 5 },
        { 3, 0 },
        { 4, 7 },
        { 5, 6 },
        { 0, 8 },
        { 2, 8 },
        { 1, -1 } // -1 表示通關
    };

    void Start() {
        animalController = GameObject.FindGameObjectWithTag("AnimalPlayer").GetComponent<AnimalController>();
        door = this.transform.Find("Door").GetComponent<Door>();
    }

    void Update() {
    }


    private void OnMouseDown() {
        if (doorPaths.ContainsKey(doorId)) {
            int nextDoorId = doorPaths[doorId];

            this.animalController.MoveFromTo(doorId, nextDoorId);

            Debug.Log($"從門 {doorId} 到門 {nextDoorId}");
        }
        else {
            Debug.Log("無效的門編號！");
        }
    }
}
