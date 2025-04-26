using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabController : MonoBehaviour
{
    //[Header("Object Type")]
    public enum ObjectType
    {
        isDrawer,
        isDoor
    };

    public ObjectType type;

    [Header("Drawer Settings")]
    [Tooltip("Max opening distance in millimeters")]
    public float drawerOpenDistance = 300f;

    [Header("Door Settings")]
    [Tooltip("Degree to open from closed position")]
    [Range(0, 180)]
    public float hingeDegree = 90f;

    public enum HingeDirection
    {
        Left,
        Right,
        Up,
        Down
    };

    public HingeDirection hingeOrientation;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (type == ObjectType.isDrawer) DrawerBehave();
        else if (type == ObjectType.isDoor) DoorBehave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawerBehave()
    {
        ConfigurableJoint confi = gameObject.AddComponent<ConfigurableJoint>();
        XRGrabInteractable grab = gameObject.AddComponent<XRGrabInteractable>();
        grab.movementType = XRBaseInteractable.MovementType.VelocityTracking;
        
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        
        ConstantForce force = gameObject.AddComponent<ConstantForce>();

        SoftJointLimit sLimit = confi.linearLimit;
        confi.axis = Vector3.right;
        confi.secondaryAxis = Vector3.up;
        confi.xMotion = ConfigurableJointMotion.Locked;
        confi.yMotion = ConfigurableJointMotion.Locked;
        confi.zMotion = ConfigurableJointMotion.Limited;
        confi.angularXMotion = ConfigurableJointMotion.Locked;
        confi.angularYMotion = ConfigurableJointMotion.Locked;
        confi.angularZMotion = ConfigurableJointMotion.Locked;
        sLimit.limit = drawerOpenDistance / 1000;
        sLimit.contactDistance = 2;
        confi.linearLimit = sLimit;

    }

    private void DoorBehave()
    {
        HingeJoint hinge = gameObject.AddComponent<HingeJoint>();
        XRGrabInteractable grab = gameObject.AddComponent<XRGrabInteractable>();
        grab.movementType = XRBaseInteractable.MovementType.VelocityTracking;
        
        //ConstantForce force = gameObject.AddComponent<ConstantForce>();
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        
        JointLimits limits = hinge.limits;
        
        hinge.useLimits = true;

        switch (hingeOrientation)
        {
            case HingeDirection.Left:
                hinge.anchor = new Vector3(0.5f, 0, 0);
                hinge.axis = Vector3.down;
                limits.min = -hingeDegree;
                limits.max = 0;
                break;
            case HingeDirection.Right:
                hinge.anchor = new Vector3(-0.5f, 0, 0);
                hinge.axis = Vector3.up;
                limits.min = -hingeDegree;
                limits.max = 0;
                break;
            case HingeDirection.Up:
                hinge.anchor = new Vector3(0, 0.5f, 0);
                hinge.axis = Vector3.right;
                limits.min = -hingeDegree;
                limits.max = 0;
                break;
            case HingeDirection.Down:
                hinge.anchor = new Vector3(0, -0.5f, 0);
                hinge.axis = Vector3.left;
                limits.min = -hingeDegree;
                limits.max = 0;
                break;
        }
        
        hinge.limits = limits;
    }
}
