using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCARDSback : MonoBehaviour
{
    public GameObject Camera;
    public void OnMouseDown()
    {
        Camera.transform.position = Camera.transform.position + Vector3.up * 10f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
