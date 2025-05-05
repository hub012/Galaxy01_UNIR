using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; 
    private int scoreValue;
    public static int finalScoreValue;
    private int _weaponUpgradeScore;

    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
        scoreValue = _weaponUpgradeScore =  0;
    }

    void Update()
    {
        finalScoreValue = scoreValue;
    }

    public void SetScore()
    {
        scoreValue++;
        _weaponUpgradeScore++;
        scoreText.text = scoreValue.ToString();
        if (_weaponUpgradeScore == 15 &&  !ProjectilePool.Instance.CanUseSuperShoot)
        { 
            _weaponUpgradeScore = 0;
           WeaponUpgradeItemPool.Instance.SpawnItem();
           
           
        }
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