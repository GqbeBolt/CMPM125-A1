using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{

    private float desired_acceleration;
    public float power;

    public WaypointController next;

    public TextMeshProUGUI timeLabel;
    float startTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(desired_acceleration * power, 0, 0));
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / 200;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }

        timeLabel.text = (Time.time - startTime).ToString() + " seconds";
    }

    void OnMove(InputValue action)
    {
        Vector2 movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
    }
}
