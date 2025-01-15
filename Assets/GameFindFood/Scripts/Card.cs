using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour{
    public Sprite[] cards;
    public Sprite back;
    
    private int index;
    private int image;
    private bool isFlipped = false;  // 用來判斷卡片是否已翻轉
    private bool isFlipping = false;  // 用來判斷卡片是否正在翻轉
    private float flipSpeed = 2.0f;  // 翻轉速度
    private float currentRotation = 0f;  // 當前旋轉角度

    private bool isMatching = false;
    private float shrinkSpeed = 2f; // 縮放速度
    public FindFoodGameManager gameManager;
    SpriteRenderer spriteRenderer;
    private Vector2[] pos = new Vector2[]{
        new Vector2(0.2f, 0.2f), 
        new Vector2(0.03f, 0.03f), 
        new Vector2(0.2f, 0.2f), 
        new Vector2(0.25f, 0.25f), 
        new Vector2(0.2f, 0.2f), 
        new Vector2(0.2f, 0.2f), 
        new Vector2(0.2f, 0.2f), 
        new Vector2(0.2f, 0.2f), 
        new Vector2(0.08f, 0.08f), 
        new Vector2(0.25f, 0.25f), 
        new Vector2(0.25f, 0.25f), 
    };

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = back;
    }

    void Update(){

        if (isFlipping){
            currentRotation = Mathf.Lerp( currentRotation, 180f, Time.deltaTime * flipSpeed );
            transform.rotation = Quaternion.Euler(0, currentRotation, 0);

            if( Mathf.Abs(currentRotation - 120f) < 1f ){
                gameManager.setCanPlay(false);
                FlipCard(); 
                isFlipped = false;
                gameManager.setCanPlay(true);
            }
            else if( Mathf.Abs(currentRotation - 180f) < 1f ){
                currentRotation = 180f;
                isFlipping = false;
            }
        }

        if (isMatching){
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * shrinkSpeed);
            if (transform.localScale.magnitude < 0.01f) Destroy(gameObject); // 銷毀物件
        }
    }

    void OnMouseDown(){
        if( spriteRenderer.sprite == back && gameManager.getCanPlay() && ( gameManager.getList() <2 )){
            this.currentRotation = 0;
            isFlipping = true;
            isFlipped = true;
            gameManager.checkCard(index);
        }
        
    }

    private void FlipCard(){
        if( isFlipped ){
            if (spriteRenderer.sprite != back ){
                spriteRenderer.sprite = back; 
                transform.localScale = pos[0];
            }
            else{
                spriteRenderer.sprite = cards[image];
                transform.localScale = pos[image+1];
            }
        }
    }


    public void setIndex( int index ){
        this.index = index;
    }

    public void setImage ( int image ){
        this.image = image;
    }

    public void setIsMatching( bool isMatching ){
        this.isMatching = isMatching;
    }

    public void setIsFlipping( bool isFlipping){
        this.isFlipping = isFlipping;
        this.isFlipped = true;
        this.currentRotation = 0;
    }
}