using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public void MovePlayer(Vector3 movementDirection, float movementSpeed)
    {
        transform.position += movementDirection * movementSpeed * Time.deltaTime;
    }

    public void ClampPlayerPosition(float minXValue, float maxXValue)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXValue, maxXValue), transform.position.y, transform.position.z);
    }

    public void RotatePlayerByMovement(Vector3 movementDirection, float maxAngleValue, float rotatingSpeed)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, maxAngleValue * -movementDirection.x), rotatingSpeed * Time.deltaTime);
    }
}
