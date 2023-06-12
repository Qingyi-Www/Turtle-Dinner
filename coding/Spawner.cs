using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] foods;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnWaitMax;
    public float spawnWaitMin;
    public int startWait;

    bool stop;
    int randFood;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnWaitMin, spawnWaitMax);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randFood = Random.Range(0, 2);
            float theta = (Ultrasonic.degrees + 70) * Mathf.PI / 180;
            Vector3 spawnPosition = new Vector3(Ultrasonic.centre_x + Ultrasonic.radius * Mathf.Cos(theta), Random.Range(2, 22), Ultrasonic.centre_z + Ultrasonic.radius * Mathf.Sin(theta));
            
            if (foods[randFood].CompareTag("Plastic"))
            {
                Instantiate(foods[randFood], spawnPosition, gameObject.transform.rotation);
            } else
            {
                Instantiate(foods[randFood], spawnPosition, new Quaternion(0, 0, 0, 0));
            }
                
            Debug.Log(spawnPosition);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
