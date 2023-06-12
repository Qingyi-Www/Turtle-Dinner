using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PlasticNum : MonoBehaviour
{
    public LifeBar lifeBar;
    public Image blinkingImage;
    private Animator animator;
    //public ScreenBlinker screenBlinker;

    // Start is called before the first frame update
    void Start()
    {
        animator = blinkingImage.GetComponent<Animator>();
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
            Food.Plastic += 1;
            lifeBar.UpdateLifeBar(Food.FoodNum - Food.Plastic, Food.FoodNum);
            Destroy(gameObject);

            //screenBlinker.StartBlinking();
            //animator.SetBool("Blinking", true);
            StartCoroutine(TriggerWithDelay());
            Debug.Log("Blinking enabled");

            //blinkingImage.enabled = false;

        }

    }

    private IEnumerator TriggerWithDelay()
    {
        blinkingImage.enabled = true;
        animator.Play("Blinking");
        yield return new WaitForSeconds(1f); // Wait for 1 second
    }


}
