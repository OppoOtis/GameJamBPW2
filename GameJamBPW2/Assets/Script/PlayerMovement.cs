using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    public float maxSpeed;
    public float maxBackwardsSpeed;
    public float rotSpeed;
    public CharacterController player;

    void Update()
    {
        float H = Input.GetAxisRaw("Horizontal");

        Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
        newRotation *= Quaternion.Euler(0, H * rotSpeed, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 4 * Time.deltaTime);

        if (Input.GetKey(KeyCode.W)) {
            UpSpeed();
        }
        else {
            DownSpeed();
        }

        if (Input.GetKey(KeyCode.S)) {
            BackUpSpeed();
        }
        else {
            BackDownSpeed();
        }

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void UpSpeed() {
        if(speed < maxSpeed) {
            speed += .5f;
        }
    }
    void DownSpeed() {
        if (speed > 0) {
            speed -= .5f;
        }
    }

    void BackUpSpeed() {
        if (speed > -maxBackwardsSpeed) {
            speed -= .5f;
        }
    }
    void BackDownSpeed() {
        if (speed < 0) {
            speed += .5f;
        }
    }
}
