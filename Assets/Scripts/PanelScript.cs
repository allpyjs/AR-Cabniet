using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public GameObject m_Panel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void HidePanel()
    {
        m_Panel.transform.position = m_Panel.transform.position + new Vector3(-500, 0, 0);
    }
    
    public void ShowPanel()
    {
        m_Panel.transform.position = m_Panel.transform.position + new Vector3(500, 0, 0);
    }
}
