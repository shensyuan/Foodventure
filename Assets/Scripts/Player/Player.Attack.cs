using UnityEngine;

public partial class Player : MonoBehaviour {
    Animator animator;
    void Attack() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            animator.SetBool("Attack", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            animator.SetBool("Attack", false);
        }
        // int? toolId = Inventory.GetComponent<Inventory>().selectedItem?.id;
        // animator.SetBool("UseTool", toolId == 2 || toolId == 4);
    }
}