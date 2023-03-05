using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCARDS : MonoBehaviour
{
    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.transform.position = Camera.transform.position + Vector3.down * 10f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
