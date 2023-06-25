using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyscoreText;
    public Text MyscoreText2;
    private int ScoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNumber = 0;
        UpdateScoreText();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "MyCoin")
        {
            ScoreNumber++;
            Destroy(Coin.gameObject);
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        MyscoreText.text = "Coins: " + ScoreNumber;
        MyscoreText2.text = "Coins: " + ScoreNumber;
    }

    public int GetCoinCount()
    {
        return ScoreNumber;
    }

    public void SetCoinCount(int count)
    {
        ScoreNumber = count;
        UpdateScoreText();
    }
}
