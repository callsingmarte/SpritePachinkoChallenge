using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }

    private void disableBall()
    {
        this.gameObject.SetActive(false);
        GameObject spawner = GameObject.Find("Spawner");
        spawner.GetComponent<Spawner>().setCanSpawn(true);
        spawner.GetComponent<Spawner>().canSpawnToggleDisplay(true);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.parent != null) {
            if (collision.gameObject.transform.parent.name.Equals("Boundaries"))
            {
                disableBall();
            }
        }
        if (collision.gameObject.name.Contains("ScoreBox"))
        {
            if (collision.gameObject.name.Contains("ScoreBoxType1"))
            {
                score += 1;
                scoreText.text = score.ToString();
            }
            if (collision.gameObject.name.Contains("ScoreBoxType2"))
            {
                score -= 1;
                if(score < 0)
                {
                    score = 0;
                }
                scoreText.text = score.ToString();
            }
            if (collision.gameObject.name.Contains("ScoreBoxType3"))
            {
                score *= 2;
                scoreText.text = score.ToString();
            }
            if (collision.gameObject.name.Contains("ScoreBoxType4"))
            {
                score /= 2;
                scoreText.text = score.ToString();
            }
            disableBall();
        }
    }
}
