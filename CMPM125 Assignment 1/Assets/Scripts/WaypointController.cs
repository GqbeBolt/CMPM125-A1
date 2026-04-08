using UnityEngine;


public class WaypointController : MonoBehaviour
{


    public WaypointController next;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var vehicle = other.gameObject.GetComponent<VehicleController>();
        if (vehicle != null)
        {
            Debug.Log("hey");
        }
    }
}
