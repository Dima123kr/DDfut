using UnityEngine;
using UnityEngine.EventSystems;

public class ClickFREEPACK : MonoBehaviour
{
    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.transform.position = Camera.transform.position + Vector3.right * 30.5f + Vector3.down * 22f + Vector3.back * 72f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
