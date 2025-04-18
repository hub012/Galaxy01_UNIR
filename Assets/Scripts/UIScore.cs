using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; 
    [SerializeField] private int scoreValue; 
    // Start is called before the first frame update
    void Start()
    {
        SetScore(scoreValue);
    }

    // Update is called once per frame
    void Update()
    {
        SetScore(scoreValue);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}