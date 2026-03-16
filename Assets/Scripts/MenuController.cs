using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    void OnGUI()
    {
        GUIStyle titleStyle = new GUIStyle(GUI.skin.label);
        titleStyle.fontSize = 42;
        titleStyle.alignment = TextAnchor.MiddleCenter;
        titleStyle.fontStyle = FontStyle.Bold;
        titleStyle.normal.textColor = new Color(0.2f, 1f, 0.2f);


        GUIStyle textStyle = new GUIStyle(GUI.skin.label);
        textStyle.fontSize = 20;
        textStyle.alignment = TextAnchor.MiddleCenter;
        textStyle.normal.textColor = Color.white;

        GUI.Label(
            new Rect(0, Screen.height / 3, Screen.width, 420),
            "Use as setas para mover\nEspaço para atirar",
            textStyle
        );

        Rect buttonRect = new Rect(
            (Screen.width - 200) / 2,
            Screen.height / 2,
            200,
            50
        );

        if (GUI.Button(buttonRect, "START GAME"))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetForNewGame();
        }

        SceneManager.LoadScene("GameScene");
    }
}