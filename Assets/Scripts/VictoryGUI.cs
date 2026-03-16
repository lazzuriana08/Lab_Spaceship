using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryGUI : MonoBehaviour
{
    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 40;
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = Color.red;

        if (ScoreManager.instance != null)
        {
            GUI.Label(
                new Rect(
                    (Screen.width - 400) / 2,
                    (Screen.height / 2) - 100,
                    420,
                    50
                ),
                "Final Score: " + ScoreManager.instance.score,
                style
            );
        }

        Rect buttonRect = new Rect(
            (Screen.width - 200) / 2,
            (Screen.height / 1) - 120,
            200,
            50
        );


        if (GUI.Button(buttonRect, "MENU"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}