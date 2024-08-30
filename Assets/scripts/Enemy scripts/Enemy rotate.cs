using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Rotation speed around each axis (in degrees per second)
    public Vector3 rotationSpeed = new Vector3(0, 0, 100); // Default: rotate around the Y axis

    // Update is called once per frame
    void Update()
    {
        // Rotate the object based on the rotationSpeed and the time passed since last frame
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}

