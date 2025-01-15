using UnityEngine;

public class SyncPhysicsObject : MonoBehaviour
{
    Rigidbody rigidbody3D;
    ConfigurableJoint joint;

    [SerializeField] Rigidbody animatedRigidbody3D;

    [SerializeField] bool syncAnimation = false;
    Quaternion startLocalRotation;

    
    void Start()
    {
        
    }

    void Awake(){

        rigidbody3D = GetComponent<Rigidbody>();

        joint = GetComponent<ConfigurableJoint>();

        //store the starting local rotation

        startLocalRotation = transform.localRotation;

    }

    public void UpdateJointFromAnimation(){

        if(!syncAnimation)

        return;

        ConfigurableJointExtensions.SetTargetRotationLocal(joint, animatedRigidbody3D.transform.localRotation, startLocalRotation);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}