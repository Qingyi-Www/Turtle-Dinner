using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Food : MonoBehaviour
{
    public static int FoodNum;
    public static int Plastic;
    public static float danger_rate;
    public static int gameOver;

    // Start is called before the first frame update
    void Start()
    {
        FoodNum = 0;
        Plastic = 0;
        danger_rate = 0;
        int gameOver = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Food.Plastic > 0 && Food.Plastic >= Food.FoodNum)
        {
            SceneManager.LoadScene("Start/Scenes/gameover");
            Debug.Log("Game over! ");
        }
    }

    void OnGUI()
    {

        float boxWidth = Screen.width * 0.2f;
        float edge = Screen.width * 0.07f;
        GUIStyle guiStyle = new GUIStyle(GUI.skin.box);
        guiStyle.alignment = TextAnchor.MiddleCenter;
        guiStyle.fontSize = 24;

        GUI.Box(new Rect(edge, 40, boxWidth, boxWidth * 0.5f), "Food Eaten: \n\n" + FoodNum.ToString(), guiStyle);
        //GUI.color = Color.red;
        if (Food.FoodNum != 0)
        {
            danger_rate = (float) Food.Plastic / Food.FoodNum;
        }
        GUI.color = new Color(1f, 1f - danger_rate * 220f / 255f, (1f - danger_rate) * 255f);
        GUI.Box(new Rect(Screen.width - edge - boxWidth, 40, boxWidth, boxWidth * 0.5f), "Plastic Bag Eaten: \n\n" + Plastic.ToString(), guiStyle);

    }
}
