using UnityEngine;

public partial class Player : MonoBehaviour {
    [SerializeField] Transform targetCamera;
    private Vector3 initPosition;
    private float cameraXRotation = 0;
    private float cameraYRotation = 0;
    
    void SightInit() {
        initPosition = targetCamera.localPosition;
    }

    void Sight() {
        //if (Cursor.lockState != CursorLockMode.Locked) return;

        float deltaX = Input.GetAxis("Mouse X") * 5;
        float deltaY = Input.GetAxis("Mouse Y") * 5;
        bool freeCamera = Input.GetKey(KeyCode.LeftAlt);

        if (!freeCamera) {
            cameraYRotation = 0;
            transform.Rotate(0, deltaX * Time.deltaTime * 100, 0);
        }
        else {
            cameraYRotation -= deltaX;
        }
        
        cameraXRotation -= deltaY * Time.deltaTime * 60;
        cameraXRotation = Mathf.Max(-70, Mathf.Min(90, cameraXRotation));
        Vector3 vec = initPosition;
        vec.y = 0;
        vec = Quaternion.Euler(cameraXRotation, cameraYRotation, 0) * vec;
        vec.x = vec.x * (90 - Mathf.Abs(cameraXRotation)) / 90f;
        vec.y += initPosition.y;
        targetCamera.localPosition = vec;
        targetCamera.localRotation = Quaternion.Euler(cameraXRotation, cameraYRotation, 0);
    }
}
