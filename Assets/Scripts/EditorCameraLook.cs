using UnityEngine;

public class EditorCameraLook : MonoBehaviour
{
    public float mouseSensitivity = 3f;

    private float rotationX;
    private float rotationY;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;
    }

    void Update()
    {
#if UNITY_EDITOR
        // Hold RIGHT mouse button to look around in the editor
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            rotationY = Mathf.Clamp(rotationY, -80f, 80f);

            transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
        }
#endif
    }
}