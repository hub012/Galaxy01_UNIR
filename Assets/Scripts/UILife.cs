using System;
using UnityEngine;
using UnityEngine.UI;

public class UILife : MonoBehaviour
{
    [SerializeField] private Image lifeImage;
    [SerializeField] private float imageFillAmountValue;
    // Start is called before the first frame update
    void Start()
    {
        ChangeFillAmountValue(lifeImage, imageFillAmountValue);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void ChangeFillAmountValue(Image image, float fillAmount)
    {
        image.fillAmount = fillAmount;
    }

    private void OnEnable()
    {
        Player.OnPlayerHealthChanged += UpdateLifeUI;
    }

    private void OnDisable()
    {
        Player.OnPlayerHealthChanged -= UpdateLifeUI;
    }
    
    private void UpdateLifeUI(float newValue)
    {
       
        ChangeFillAmountValue(lifeImage, newValue);
    }
}
