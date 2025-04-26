using UnityEngine;

public class DoorController : MonoBehaviour
{
    private ConstantForce cForce;

    private float amount = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cForce = GetComponent<ConstantForce>();
        if(gameObject.tag == "Inverse") amount = -amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoor()
    {
        if (cForce.torque.y == -amount) OpenDoor();
        else CloseDoor();
    }
    
    public void OpenDoor()
    {
        cForce.torque = new Vector3(0, amount, 0);
    }
    
    public void CloseDoor()
    {
        cForce.torque = new Vector3(0, -amount, 0);
    }
}
