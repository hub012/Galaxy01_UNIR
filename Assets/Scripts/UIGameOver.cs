using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
     [SerializeField] private TMP_Text highScoreText; 
    // Start is called before the first frame update
    void Start()
    {
         highScoreText.text = "High Score: " + UIScore.finalScoreValue;
    }


}
