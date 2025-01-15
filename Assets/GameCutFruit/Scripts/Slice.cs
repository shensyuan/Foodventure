using UnityEngine;

public class BladeScript : MonoBehaviour
{
    private Vector3 lastMousePosition;
    private Collider bladeCollider;

    void Start()
    {
        bladeCollider = GetComponent<Collider>();
        bladeCollider.enabled = false;
    }

    void Update()
    {
        // 按住左鍵啟用刀刃
        if (Input.GetMouseButton(0))
        {
            bladeCollider.enabled = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;

            // 設定刀刃方向
            if (lastMousePosition != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - lastMousePosition);
            }

            lastMousePosition = mousePosition;
        }
        else
        {
            bladeCollider.enabled = false;
            lastMousePosition = Vector3.zero;
        }
    }
}
