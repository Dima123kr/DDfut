using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDRAFTback : MonoBehaviour
{
    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.transform.position = Camera.transform.position + Vector3.left * 20f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
