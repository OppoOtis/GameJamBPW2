using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    float round;

    private void OnTriggerEnter(Collider other) {
        round--;
    }

    private void Update() {
        if(round < 1) {
            
        }
    }
}