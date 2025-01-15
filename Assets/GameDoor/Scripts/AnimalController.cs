using System;
using System.Collections.Generic;
using System.Diagnostics;
using DoorScript;
using UnityEngine;

class Command {
    public int type;
    public Vector3 targetPosition;
    public Quaternion targetRotation;
    public bool transform = true;
    public Action action = null;

    public Command(Vector3 targetPosition, bool transform = true) {
        this.transform = transform;
        this.type = 0;
        this.targetPosition = targetPosition;
        this.targetRotation = Quaternion.identity;
    }

    public Command(Quaternion targetRotation, bool transform = true) {
        this.transform = transform;
        this.type = 1;
        this.targetPosition = Vector3.zero;
        this.targetRotation = targetRotation;
    }

    public Command(Action action) {
        this.type = 2;
        this.action = action;
    }
}

public class AnimalController : MonoBehaviour {
    [SerializeField] float moveSpeed = 20f; // 移動速度
    [SerializeField] float rotateSpeed = 30f; // 移動速度
    [SerializeField] List<Transform> doors = new List<Transform>();
    [SerializeField] Generate generator;
    [SerializeField] CountdownTimer timer;
    [SerializeField] DoorCameraControl doorCameraControl;
#nullable enable
    private Command? currentCommand = null;
    private Queue<Command> commands = new Queue<Command>();
    private int currentLayer = 0;

    void Start() {
        // targetPosition = transform.position; // 初始位置
    }

    void Update() {
        if (currentCommand == null) {
            if (commands.Count == 0) {
                return;
            }
            currentCommand = commands.Dequeue();
        }

        if (currentCommand.type == 0) {
            if (currentCommand.transform) {
                transform.position = Vector3.MoveTowards(transform.position, currentCommand.targetPosition, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, currentCommand.targetPosition) < 0.1f) {
                    transform.position = currentCommand.targetPosition;
                    currentCommand = null;
                }
            }
            else {
                transform.position = currentCommand.targetPosition;
                currentCommand = null;
            }
        }
        else if (currentCommand.type == 1) {
            if (currentCommand.transform) {
                transform.rotation = Quaternion.Slerp(transform.rotation, currentCommand.targetRotation, rotateSpeed * Time.deltaTime);
                if (Quaternion.Angle(transform.rotation, currentCommand.targetRotation) < 0.1f) {
                    transform.rotation = currentCommand.targetRotation;
                    currentCommand = null;
                }
            }
            else {
                transform.rotation = currentCommand.targetRotation;
                currentCommand = null;
            }
        }
        else if (currentCommand.type == 2) {
            currentCommand.action();
            currentCommand = null;
        }
    }

    public void MoveFromTo(int from, int to) {
        if (commands.Count > 0) {
            return;
        }
        if (2 - (from / 3) != currentLayer) {
            return;
        }
        currentLayer = 2 - (to / 3);

        Vector3 frontOfDoor = new Vector3(
            doors[from].position.x,
            doors[from].position.y,
            transform.position.z
        );
        Action switchFromDoor = doors[from].Find("Door").GetComponent<Door>().OpenDoor;
        Action? switchToDoor = to == -1 ? null : doors[to].Find("Door").GetComponent<Door>().OpenDoor;

        // Rotate to enter door
        int targetAngle = frontOfDoor.x > this.transform.position.x ? 90 : 270;
        if (Math.Abs(frontOfDoor.x - this.transform.position.x) > 2f) {
            Quaternion walkRotation = Quaternion.Euler(
                0, targetAngle, 0
            );
            commands.Enqueue(new Command(walkRotation));
        }
        // Move to door
        commands.Enqueue(new Command(frontOfDoor));

        // Open door
        commands.Enqueue(new Command(switchFromDoor));

        // Rotate to face door
        targetAngle = targetAngle == 90 ? 0 : 360;
        commands.Enqueue(new Command(Quaternion.Euler(0, targetAngle, 0)));

        // Move into door
        frontOfDoor.z += 20;
        commands.Enqueue(new Command(frontOfDoor));

        // Close door
        commands.Enqueue(new Command(switchFromDoor));

        if (to == -1) {
            commands.Enqueue(new Command(() => {
                this.generator.StartGenerate();
                timer.GameOver(true);
            }));
            return;
        }

        // Move Camera
        commands.Enqueue(new Command(() => {
            doorCameraControl.UpdateTargetY(25 - 10 * (to / 3));
        }));
        
        // Move to another door
        commands.Enqueue(new Command(new Vector3(
            doors[to].position.x,
            doors[to].position.y,
            transform.position.z + 20
        ), false));

        // Rotate to face door
        commands.Enqueue(new Command(Quaternion.Euler(0, 180, 0), false));

        // Open door
        commands.Enqueue(new Command(switchToDoor));

        // Move out door
        commands.Enqueue(new Command(new Vector3(
            doors[to].position.x,
            doors[to].position.y,
            transform.position.z
        )));

        // Close door
        commands.Enqueue(new Command(switchToDoor));
    }
}

