using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOTHERSback : MonoBehaviour
{
    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.transform.position = Camera.transform.position + Vector3.right * 20f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
