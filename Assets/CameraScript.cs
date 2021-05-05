using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speed = 100f;

    float rotationOnX;
    float mouseSensitivity = 90f;
    public Transform player;
    
    void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        player.transform.position += moveDirection * Time.deltaTime * speed;

        /////////////

        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime* mouseSensitivity;
        float m_X = Input.GetAxis("Mouse X") * Time.deltaTime* mouseSensitivity;

        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        player.Rotate(Vector3.up * m_X);

    }
}
