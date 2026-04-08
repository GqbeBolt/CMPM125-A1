using UnityEngine;


public class WaypointController : MonoBehaviour
{


    public WaypointController next;

    public MeshRenderer left, right;

    public bool lastPoint = false;
    

    private void OnTriggerEnter(Collider other)
    {
        var vehicle = other.gameObject.GetComponent<VehicleController>();
        if (vehicle != null)
        {
            next.left.materials[0].color = Color.red;
            next.right.materials[0].color = Color.red;

            left.materials[0].color = Color.white;
            right.materials[0].color = Color.white;

            if (lastPoint)
            {
                vehicle.resetTime();
                vehicle.lapDone();
            }
        }
    }
}
