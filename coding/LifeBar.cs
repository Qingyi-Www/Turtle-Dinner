using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private Image fillimage;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1f;
        fillimage.color = GetColorFromColormap(1f);
        textMeshPro.color = GetColorFromColormap(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLifeBar(int curr_value, int max_value)
    {
        float proportion = (float)curr_value / (float)max_value;
        slider.value = proportion;
        Color fillcolor = GetColorFromColormap(proportion);
        fillcolor.a = 0.9f;
        fillimage.color = fillcolor;
        textMeshPro.color = fillcolor;

    }


    // get fill color from a customized "red-yellow-green" colormap
    public Color GetColorFromColormap(float value)
    {
        Color redColor = Color.red;
        Color yellowColor = Color.yellow;
        Color greenColor = Color.green;

        if (value <= 0.5f)
        {
            return Color.Lerp(redColor, yellowColor, value * 2f);
        }
        else
        {
            return Color.Lerp(yellowColor, greenColor, (value - 0.5f) * 2f);
        }
    }

}
