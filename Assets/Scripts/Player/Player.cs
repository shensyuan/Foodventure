using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(MoveComponent))]

public partial class Player : MonoBehaviour
{
    MoveComponent moveComponent;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
        moveComponent = transform.GetComponent<MoveComponent>();
        Debug.Log("start");
        SightInit();
        
    }



    void Update()
    {
        // Calculate weight
        int x_delta = 0, z_delta = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) z_delta++;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) z_delta--;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x_delta++;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) x_delta--;

        moveComponent.Move(
            x_delta,
            z_delta,
            Input.GetKey(KeyCode.LeftShift)
        );
        if (Input.GetKeyDown(KeyCode.Space)) moveComponent.Jump();

        // // if (Input.GetKeyDown(KeyCode.Mouse0) && GameData.LockCursor) {
        // //     Cursor.lockState = CursorLockMode.Locked;
        // // }

        // // if (Input.GetKeyDown(KeyCode.Escape)) {
        // //     GameData.Pause = true;
        // // };
        // // if (Input.GetKeyDown(KeyCode.E)) {
        // //     GameData.OpenBackPack = !GameData.OpenBackPack;
        // // };
        Sight();

        Attack();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene("2D"); //"切換場景名"
        }


    }

}
