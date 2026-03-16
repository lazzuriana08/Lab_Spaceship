using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int lives = 2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value) { score += value; }
    public void AddLife(int value) { lives += value; }

    public void LoseLife()
    {
        if (lives <= 0) return;

        lives--;

        if (lives <= 0)
        {
            lives = 0;
            GameManager.instance.GameOver();
        }
    }

    public void ResetForNewGame()
    {
        score = 0;
        lives = 2;
    }

    void OnGUI()
    {
        string scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (scene == "GameScene")
        {
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.fontSize = 30;
            style.alignment = TextAnchor.UpperLeft;
            style.normal.textColor = Color.yellow;

            GUI.Label(new Rect(20, 20, 200, 50), "Score: " + score, style);
            GUI.Label(new Rect(20, 60, 200, 50), "Lives: " + lives, style);
        }
    }
}