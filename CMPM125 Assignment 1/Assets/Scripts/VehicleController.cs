using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{

    private float desired_accelerationX;
    private float desired_accelerationZ;
    public float power;
    public float turnSpeed;

    public WaypointController next;

    public TextMeshProUGUI timeLabel;
    public TextMeshProUGUI lapLabel;
    int laps = 0;
    float startTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
        next.left.materials[0].color = Color.red;
        next.right.materials[0].color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(desired_accelerationX * power, 0, desired_accelerationZ * power));
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / 200;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx/20 * turnSpeed, 0);
        }

        timeLabel.text = string.Format("Current Lap Time: {0:F2} seconds", (Time.time - startTime));
        lapLabel.text = string.Format("Laps Done: {0}", laps);
        //timeLabel.text = "Current Lap Time: " + Mathf.Round((Time.time - startTime) * 100) / 100 + " seconds";
        //Debug.Log("forward: " + desired_accelerationX + " | Side: " + desired_accelerationZ);
    }

    void OnMove(InputValue action)
    {
        Vector2 movement = action.Get<Vector2>();
        desired_accelerationZ = -movement.x;
        desired_accelerationX = movement.y;
       
    }

    public void resetTime()
    {
        startTime = Time.time;    
    }

    public void lapDone()
    {
        laps++;
    }
}
