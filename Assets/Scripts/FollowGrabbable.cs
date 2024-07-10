using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGrabable : MonoBehaviour
{
    // Reference to the grabbable sphere object
    public Transform grabbableSphere;

    // Rotation offset to rotate the plane 90 degrees around its up axis
    public Vector3 rotationOffset = new Vector3(0f, 0f, 0f);

    // Update is called once per frame
    void Start()
    {
        // Update the position of the plane to match the grabbable sphere
        transform.position = grabbableSphere.position;

        // Calculate the direction from the plane to the camera
        Vector3 planeToCamera = Camera.main.transform.position - transform.position;

        // Apply the rotation offset
        Quaternion targetRotation = Quaternion.LookRotation(planeToCamera) * Quaternion.Euler(rotationOffset);

        // Apply the rotation to the plane
        transform.rotation = targetRotation;
    }
}
