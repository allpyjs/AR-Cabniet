using UnityEngine;

public class DrawerController : MonoBehaviour
{
    private ConstantForce cForce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cForce = GetComponent<ConstantForce>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ToggleDrawer()
    {
        if (cForce.force.z == -5) OpenDrawer();
        else CloseDrawer();
    }
    
    public void OpenDrawer()
    {
        cForce.force = new Vector3(0, 0, 5);
    }
    
    public void CloseDrawer()
    {
        cForce.force = new Vector3(0, 0, -5);
    }
}
