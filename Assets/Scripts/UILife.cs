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
        ChangeFillAmountValue(lifeImage, imageFillAmountValue);
    }
    void ChangeFillAmountValue(Image image, float fillAmount)
    {
        image.fillAmount = fillAmount;
    }
}
