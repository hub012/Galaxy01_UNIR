using UnityEngine;
using UnityEngine.UI;

public class UIWeaponUpgrade : MonoBehaviour
{
    [SerializeField] private Image weaponUpgradeImage;
    [SerializeField] private float imageAlphaValue;
    [SerializeField] private bool isWeaponEquipped;
    // Start is called before the first frame update
    void Start()
    {
        ChangeImageTransparency(weaponUpgradeImage, imageAlphaValue);
    }

    void ChangeImageTransparency(Image image, float transparencyValue)
    {
        var tempColor = image.color;

        tempColor.a = transparencyValue;
        
        image.color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWeaponEquipped)
        {
            OnWeaponEquipped();
        }
        
        if(!isWeaponEquipped)
            OnWeaponLost();
       
    }

    private void OnWeaponEquipped()
    {
        const float transparencyValue = 1f;
        ChangeImageTransparency(weaponUpgradeImage, transparencyValue);
    }
    
    private void OnWeaponLost()
    {
        ChangeImageTransparency(weaponUpgradeImage, imageAlphaValue);
    }
}