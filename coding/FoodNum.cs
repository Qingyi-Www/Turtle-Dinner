using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodNum : MonoBehaviour
{
    public LifeBar lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Collision! ");
            Food.FoodNum += 1;
            lifeBar.UpdateLifeBar(Food.FoodNum - Food.Plastic, Food.FoodNum);
            Destroy(gameObject);
        }
    }
}
