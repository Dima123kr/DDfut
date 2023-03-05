using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFREEPACK : MonoBehaviour
{
    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.transform.position = Camera.transform.position + Vector3.right * 74.3f + Vector3.down * 8f + Vector3.forward * 5.4f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
