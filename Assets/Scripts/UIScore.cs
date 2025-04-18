using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; 
    private int scoreValue; 
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetScore()
    {
        scoreValue++;
        scoreText.text = scoreValue.ToString();
    }
    
    private void OnEnable()
    {
        Enemy.OnPlayerScoreChanged += SetScore;
    }

    private void OnDisable()
    {
        Enemy.OnPlayerScoreChanged -= SetScore;
    }
}