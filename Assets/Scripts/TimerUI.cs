using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private Text counterText;

    [SerializeField]
    private Text counterText2;

    private float initialTime;

    void Start()
    {
        if (counterText == null)
        {
            Debug.LogWarning("Start counting");
        }
        else
        {
            ResetTimer();
            counterText.text = "00:00";
        }
    }

    void Update()
    {
        if (counterText == null)
        {
            return;
        }

        float elapsedTime = Time.time - initialTime; // Calculate the elapsed time

        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);

        counterText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        counterText2.text=counterText.text;
    }

    public void ResetTimer()
    {
        //Debug.LogWarning("in reset timer");
        initialTime = Time.time; // Reset the initial time
        counterText.text = "00:00";
    }
}
