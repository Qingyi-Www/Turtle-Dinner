using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBlinker : MonoBehaviour
{
    public Camera mainCamera;
    private bool isBlinking = false;
    private float blinkDuration = 1f; // Duration of the blink in seconds
    private float blinkTimer = 0f;
    private float blinkInterval = 0.1f; // Interval between blink color changes
    private float initialGamma;

    
    // Start is called before the first frame update
    void Start()
    {
        initialGamma = QualitySettings.activeColorSpace == ColorSpace.Gamma ? 1f : 2.2f;

    }

    // Update is called once per frame
    void Update()
    {
        if (isBlinking)
        {
            blinkTimer += Time.deltaTime;

            if (blinkTimer >= blinkDuration)
            {
                StopBlinking();
            }
            else
            {
                float t = Mathf.PingPong(Time.time, blinkInterval) / blinkInterval;
                float gamma = Mathf.Lerp(initialGamma, 0f, t);
                mainCamera.backgroundColor = new Color(gamma, 0f, 0f);
            }
        }
    }

    public void StartBlinking()
    {
        isBlinking = true;
        blinkTimer = 1f;
        Debug.Log("BLINK!");
    }

    private void StopBlinking()
    {
        isBlinking = false;
        mainCamera.backgroundColor = Color.black; // Set the desired default background color after blinking
    }

}
