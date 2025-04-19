using System;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponUpgrade : MonoBehaviour
{
    public static UIWeaponUpgrade Instance { get; private set; }
    [SerializeField] private Image weaponUpgradeImage;
    [SerializeField] private float imageAlphaValue;
    [SerializeField] private bool isWeaponEquipped;

    private void Awake()
    {
        Instance = this;
    }

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
    /*
    void Update()
    {
     
        if (isWeaponEquipped)
        {
            OnWeaponEquipped();
        }
        
        if(!isWeaponEquipped)
            OnWeaponLost();
       
    }
   */
    public void OnWeaponEquipped()
    {
        const float transparencyValue = 1f;
        Debug.Log(transparencyValue);
        ChangeImageTransparency(weaponUpgradeImage, transparencyValue);
    }
    
    public void OnWeaponLost()
    {
        ChangeImageTransparency(weaponUpgradeImage, imageAlphaValue);
    }
}