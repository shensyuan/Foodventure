using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FindFoodGameManager : MonoBehaviour{
    
    private int num = 10;
    private int[] cardIndex;
    public CardController cardController;
    public Card cards;
    private List<int> flippedCards;
    private bool canPlay;

    public float timeRemaining ;

    public Text Score;
    public Text timerText;
    public int score;

    void Start(){
        canPlay = true;
        cardIndex = new int[ num*2 ];
        for( int i = 0 ; i<num*2 ; i++ ) cardIndex[i] = -1;
        initCard();
        flippedCards = new List<int>();
    }

    void Update(){
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        Score.text = $"Remaining :{score}";
        if ((score == 0 || timeRemaining == 0 )) {//可以換場景
            if( score == 0 ) PlayerPrefs.SetInt("Success", 1);
            else PlayerPrefs.SetInt("Success", 0); 
            SceneManager.LoadScene("Settlement");// 換到結算畫面
            
        }
    }

    void initCard(){
        
        for( int i = 0 ; i < num ; i++ ){
            int tmpa = 0  , tmpb = 0;
            for( int j = 0 ; j < 2 ; j++ ){ 
                int rad = Random.Range( 0 , num*2 );
                bool check = true;

                while( check ){
                    if( cardIndex[rad] == -1 ){
                        cardController.createCard( rad , i );
                        check = false;
                        cardIndex[rad] = rad;
                    }
                    else rad = Random.Range( 0 , num*2 );
                }
        
                if( j == 0 ) tmpa = rad;
                else if( j == 1 ) tmpb = rad;
            }
            cardIndex[tmpa] = tmpb;
            cardIndex[tmpb] = tmpa;
            Debug.Log( $"{tmpa} , {tmpb}");
            
        }
    }

    public void checkCard( int index ){
        if( flippedCards.Count == 1 && flippedCards[0] == index ) return;
        
        flippedCards.Add(index);
        
        if( flippedCards.Count == 2 ){
            canPlay = false;
            if( cardIndex[flippedCards[0]] == flippedCards[1] ) StartCoroutine(matchCard(flippedCards[0] , flippedCards[1]));
            else StartCoroutine(resetCard(flippedCards[0] , flippedCards[1]));
        }
    }

    IEnumerator resetCard( int indexA , int indexB ){
        yield return new WaitForSeconds(1f); 
        cardController.reset(indexA , indexB);
        flippedCards = new List<int>();
        canPlay = true;
    }

    IEnumerator matchCard( int indexA , int indexB ){
        yield return new WaitForSeconds(1f); 
        score--;
        cardController.match(indexA , indexB); 
        flippedCards = new List<int>();
        canPlay = true;
    }

    public bool getCanPlay(){
        return canPlay;
    }

    public void setCanPlay( bool canPlay ){
        this.canPlay = canPlay;
    }

    public int getList(){
        return flippedCards.Count;
    }

    void UpdateTimerText(){
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}