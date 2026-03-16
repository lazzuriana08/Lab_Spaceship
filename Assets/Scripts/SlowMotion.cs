using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float slowFactor = 0.5f;
    public float duration = 3f;

    public void ActivateSlow()
    {
        Time.timeScale = slowFactor;

        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Invoke("ResetTime", duration * slowFactor); 
    }

    void ResetTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}