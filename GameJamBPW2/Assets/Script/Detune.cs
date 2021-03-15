using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detune : MonoBehaviour
{
    public GameObject[] Cars;

    public float rotationSpeed = 1f;

    public static int activeCarInt = 0;

    public bool isTriggered = false;

    void Start()
    {

    }

    void Update()
    {
        foreach (var car in Cars)
        {
            car.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }

    public void DetuneCar()
    {
        if (isTriggered == false)
        {
            activeCarInt++;
            Debug.Log("Pressed");

            if (activeCarInt == 0)
            {
                ActiveCar();
                Cars[0].SetActive(true);
            }
            else if (activeCarInt == 1)
            {
                ActiveCar();
                Cars[1].SetActive(true);
            }
            else if (activeCarInt == 2)
            {
                ActiveCar();
                Cars[2].SetActive(true);
            }
        }

        isTriggered = true;

        if (isTriggered == true)
        {
            Invoke("NextScene", 3);
        }
    }

    public void ActiveCar()
    {
        foreach (var car in Cars)
        {
            car.SetActive(false);
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Next Scene");
    }
}
