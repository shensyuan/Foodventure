using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite stateSprite;
    public Collider2D groundCollider;  // 地面物体的Collider
    public Collider2D playerCollider;
    private bool isGrounded = true;
    private bool atUp = false;
    float jumpTimer = 0f;
    float runTimer = 0f;
    private float endTime = 3f;
    public static bool gameover = false;
    public static bool win = false;

    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {

        if (gameover) {
            endTime -= Time.deltaTime;
            if (endTime <= 0) {
                SceneManager.LoadScene("Settlement");// 換到結算畫面
            }
            // if (order.changeScence && Input.GetKeyDown(KeyCode.E)) {
            //     SceneManager.LoadScene("Settlement");
            // }
        }
        else {
            runTimer += Time.deltaTime;
            if (this.transform.position.y > 54.08f || this.transform.position.y < 22.49f) {
                gameover = true;
                return;
            }
            if (!playerCollider.IsTouching(groundCollider) && isGrounded) {
                if (atUp) {
                    ChangeToNewSprite(upSprite);
                    Fall(atUp);
                }
                else {
                    ChangeToNewSprite(downSprite);
                    Fall(atUp);
                }
            }
            if (runTimer >= 0.01f) {
                runTimer = 0f;
                this.transform.position += new Vector3(0.065f, 0, 0);
            }
            if (!isGrounded) {
                Jump(atUp);
            }
            if (Input.GetKeyDown(KeyCode.Space) && !atUp) {
                ChangeToNewSprite(upSprite);
                Jump(atUp);
            }
            if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.S)) && atUp) {
                ChangeToNewSprite(downSprite);
                Flip();
                Jump(atUp);
            }
        }
    }

    public void ChangeToNewSprite(Sprite newSprite) {
        if (newSprite != null) {
            spriteRenderer.sprite = newSprite;
        }
        else {
            Debug.LogWarning("新图片未设置！");
        }
    }

    void Jump(bool up) {
        if (!up) {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= 0.02f) {
                jumpTimer = 0f;
                this.transform.position += new Vector3(0, 0.7f, 0);
            }
            isGrounded = false;
        }
        else {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= 0.02f) {
                jumpTimer = 0f;
                this.transform.position -= new Vector3(0, 0.7f, 0);
            }
            isGrounded = false;
        }
    }

    void Fall(bool up) {
        if (up) {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= 0.02f) {
                jumpTimer = 0f;
                this.transform.position += new Vector3(0, 0.7f, 0);
            }
            isGrounded = true;
        }
        else {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= 0.02f) {
                jumpTimer = 0f;
                this.transform.position -= new Vector3(0, 0.7f, 0);
            }
            isGrounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground") && !isGrounded) {
            ChangeToNewSprite(stateSprite);
            jumpTimer = 0f;
            isGrounded = true;
            if (atUp) {
                //Flip();
                atUp = false;
            }
            else {
                Flip();
                atUp = true;
            }
        }
        if (collision.gameObject.tag == "orange") {
            Destroy(collision.gameObject);
            order.orange++;
        }
        if (collision.gameObject.tag == "building") {
            gameover = true;
            win = false;
        }
        if (collision.gameObject.tag == "end") {
            gameover = true;
            if (order.orange >= 6) {
                win = true;
            }
            else {
                win = false;
            }
        }
    }

    void Flip() {
        Vector3 scale = transform.localScale;
        scale.y *= -1; // 上下翻转
        transform.localScale = scale;
    }

}