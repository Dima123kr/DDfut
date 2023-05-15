using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFREEPACKback : MonoBehaviour
{
    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.transform.position = Camera.transform.position + Vector3.left * 30.5f + Vector3.up * 22f + Vector3.forward * 72f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
