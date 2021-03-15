using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    public float maxSpeed;
    public float maxBackwardsSpeed;
    public float rotSpeed;
    public Rigidbody player;

    void Update()
    {
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");

        Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
        newRotation *= Quaternion.Euler(0, H * rotSpeed, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 4 * Time.deltaTime);

        if (V > 0) {
            UpSpeed();
        }
        else {
            DownSpeed();
        }

        if (V < 0) {
            BackUpSpeed();
        }
        else {
            BackDownSpeed();
        }

        player.velocity = transform.forward * speed;
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
