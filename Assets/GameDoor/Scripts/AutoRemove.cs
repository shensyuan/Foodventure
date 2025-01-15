using UnityEngine;

public class AutoRemove : MonoBehaviour {
    [SerializeField] float lowerBound = -10f;
    // Update is called once per frame
    
    void Update() {
        if (this.transform.position.y < lowerBound) {
            Destroy(this.gameObject);
        }
    }
}
