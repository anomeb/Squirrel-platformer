using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooter : Shooter {
    public Text text;

    public Sprite haveAmmoSprite, noAmmoSprite;
    public Image nutImage, nutImage2;

    public Slider angleSlider;

    public void UpdateAngle() {
        throwAngle = angleSlider.value;
    }

    void Update() {
        text.text = "x" + missilesQuantity + "/" + maxMissilesQuantity;
        if (missilesQuantity > 0) {
            nutImage.sprite = haveAmmoSprite;
            nutImage2.sprite = haveAmmoSprite;
        }
        else {
            nutImage.sprite = noAmmoSprite;
            nutImage2.sprite = noAmmoSprite;
        }
    }
}