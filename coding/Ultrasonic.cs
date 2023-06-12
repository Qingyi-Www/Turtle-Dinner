using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Ultrasonic : MonoBehaviour
{
    string comPort;
    public static float degrees;
    public static float radius;
    public static float centre_x;
    public static float centre_z;
    float step;
    SerialPort serial;

    // Start is called before the first frame update
    void Start()
    {
        comPort = "COM3";
        serial = new SerialPort(comPort, 9600);
        serial.Open();
        degrees = 0;
        radius = 62;
        centre_x = 100;
        centre_z = 100;
        Debug.Log("START!");
    }

    // Update is called once per frame
    void Update()
    {
        MovSensor();
    }

    void MovSensor()
    {
        Vector3 pos = transform.position;
        if (serial.IsOpen)
        {
            //step = 0.7f;
            step = Food.FoodNum / 30f + 0.4f;
            try
            {
                float data = int.Parse(serial.ReadLine());
                data = Mathf.Clamp(data, 5, 80);
                data = (((data - 5) / 25) * 9) * 3 + 2;
                //data = (((data - 5) / 25) * 9) + 3;
                float theta = degrees * Mathf.PI / 180;
                transform.position = new Vector3(centre_x + radius * Mathf.Cos(theta), (int)data, centre_z + radius * Mathf.Sin(theta));
                transform.Rotate(new Vector3(0, -step, 0));
                //Debug.Log((int)data);
            }
            catch (System.Exception)
            {
                Debug.Log("Exception!");
            }
            degrees = degrees + step;
        }
    }
}
