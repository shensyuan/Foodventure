using UnityEngine;

public class DoorCameraControl : MonoBehaviour {
    private float targetY = 5;
    [SerializeField] Vector3 initialPosition = new Vector3(0, 15, -50);
    [SerializeField] float targetZ = -30f;
    [SerializeField] float moveSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        transform.position = initialPosition;
    }

    // Update is called once per frame
    void Update() {
        Vector3 targetPosition = new Vector3(initialPosition.x, targetY, targetZ);
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) {
            transform.position = targetPosition;
        }
    }

    public void UpdateTargetY(float target) {
        this.targetY = target;
    }
}
