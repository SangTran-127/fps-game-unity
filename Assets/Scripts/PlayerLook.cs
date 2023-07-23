using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera myCamera;
    private float xRotation = 0f;
    public float xSenitivity = 30f;
    public float ySenitivity = 30f;

    public void ProcessLook(Vector2 userInput)
    {
        float mouseX = userInput.x;
        float mouseY = userInput.y;
        // calculate rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySenitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // apply to our camera transform
        myCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // rotate player to look left and right
        transform.Rotate((mouseX * Time.deltaTime) * xSenitivity * Vector3.up);

    }

}
