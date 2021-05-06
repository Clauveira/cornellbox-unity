using UnityEngine;
public class CameraScript : MonoBehaviour
{
    private Vector3 _angles;
    public float speed = 0.025f;
    public float fastSpeed = 0.1f;
    public float mouseSpeed = 4.0f;
 
    private void Start()
    {
        _angles = transform.eulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    private void Update()
    {
        _angles.x -= Input.GetAxis("Mouse Y") * mouseSpeed;
        _angles.y += Input.GetAxis("Mouse X") * mouseSpeed;
        transform.eulerAngles = _angles;
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : speed;
        transform.position +=
            Input.GetAxis("Horizontal") * moveSpeed * transform.right +
            Input.GetAxis("Vertical") * moveSpeed * transform.forward;
 
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {   speed *= 1.25f; }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {   speed *= 0.75f;
        }
 
        float upDownMultiplier = 0.5f;
        if (Input.GetKey(KeyCode.E))
        { transform.position += moveSpeed * transform.up * upDownMultiplier; }
 
        if (Input.GetKey(KeyCode.Q))
        { transform.position -= moveSpeed * transform.up * upDownMultiplier; }
 
    }
}