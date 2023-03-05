using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFREEPACKback : MonoBehaviour
{
    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.transform.position = Camera.transform.position + Vector3.left * 74.3f + Vector3.up * 8f + Vector3.back * 5.4f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
