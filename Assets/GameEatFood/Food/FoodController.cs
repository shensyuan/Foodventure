using Unity.VisualScripting;
using UnityEngine;

public class FoodController : MonoBehaviour{
   
    public GameObject[] foodPrefabs;

    Vector3[] one = new Vector3[] {
        new Vector3(0, 0.45f, 0),
    };
    Vector3[] two = new Vector3[] {
        new Vector3(0.5f, 0.45f, 0),   
        new Vector3(-0.5f, 0.45f, 0)
    };
    Vector3[] three = new Vector3[] {
        new Vector3(0.8f, 0.45f, 0),   
        new Vector3(0, 0.4f, 0),   
        new Vector3(-0.8f, 0.45f, 0)  
    };
    
    void Start(){
        for( int i = 0 ; i<foodPrefabs.Length ; i++ ){
            foodPrefabs[i].SetActive(false);
        }
    }

    public void SpawnFoodOnPlate( Transform transform ){
        int radNum = Random.Range(1, 4);  
        for (int i = 0; i < radNum; i++) {
            int randomFoodIndex = Random.Range(0, foodPrefabs.Length);
            Vector3 spawnPosition ;
            if( radNum == 1 ) spawnPosition =  transform.position + one[i];
            else if ( radNum == 2 ) spawnPosition =  transform.position + two[i];
            else spawnPosition =  transform.position + three[i];
            GameObject food = Instantiate(foodPrefabs[randomFoodIndex], spawnPosition, Quaternion.identity);
            food.SetActive(true);
            food.name = food.name.Replace( "(Clone)" , "" ).Trim();
            food.transform.SetParent(transform);
            food.transform.localScale = new Vector3(0.3f, 0.3f, -1);
        }
    }


    

    void Awake(){

    }

    // Update is called once per frame
    void Update(){
        
    }

   
}





