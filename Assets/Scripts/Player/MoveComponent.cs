using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class MoveComponent : MonoBehaviour {
    [SerializeField] float Speed;
    [SerializeField] float RunSpeed;
    [SerializeField] float Gravity;
    [SerializeField] float JumpHeight;
    private Animator animator;
    private CharacterController characterController;
    private Vector3 directionVector = Vector3.zero;
    private float ySpeed = 0;
    private float nowMoveX = 0;
    private float nowMoveY = 0;
    private float lastTouchGround = 0;
    private float lastUnTouchGround = 0;

    void Start() {
        animator = transform.GetComponent<Animator>();
        characterController = transform.GetComponent<CharacterController>();
    }

    void FixedUpdate() {
        if (!characterController.isGrounded) {
            lastUnTouchGround = Time.time;
            ySpeed -= Gravity * Time.deltaTime;
        }
        else {
            lastTouchGround = Time.time;
            ySpeed = -Gravity;
            // ySpeed += Gravity * Time.deltaTime / 2f;
        }

        directionVector.y = ySpeed;
        characterController.Move(directionVector);
    }

    void UpdateAnimator(float targetX, float targetY, bool move, bool run) {
        if (move) {
            if (targetX > nowMoveX) nowMoveX += Mathf.Min(targetX - nowMoveX, Time.deltaTime * 4);
            else if (targetX < nowMoveX) nowMoveX += Mathf.Max(targetX - nowMoveX, -Time.deltaTime * 4);
            if (targetY > nowMoveY) nowMoveY += Mathf.Min(targetY - nowMoveY, Time.deltaTime * 4);
            else if (targetY < nowMoveY) nowMoveY += Mathf.Max(targetY - nowMoveY, -Time.deltaTime * 4);
            animator.SetFloat("MoveX", nowMoveX);
            animator.SetFloat("MoveY", nowMoveY);
            animator.SetFloat("MoveSpeed", run ? 1f : 0.8f);
        }
        animator.SetBool("Move", move);
        animator.SetBool("Falling", Time.time - lastTouchGround > 0.2f);
    }

    public void Move(int x, int z, bool run = false) {
        directionVector = transform.right * x + transform.forward * z;
        bool move = directionVector.magnitude > 0;
        if (move) {
            directionVector /= directionVector.magnitude;
            directionVector *= run ? RunSpeed : Speed;
        }
        UpdateAnimator(x, z, move, run);
    }

    public void Jump() {
        if (characterController.isGrounded) {
            ySpeed = JumpHeight;
            directionVector.y = JumpHeight;
            characterController.Move(directionVector);
            animator.SetBool("Jump", true);
            Utils.SetTimeout(() => {
                animator.SetBool("Jump", false);
            }, (int)(Time.deltaTime * 5 * 1000));
        }
    }
}
