using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Entity {
    MelleeAttack melleeAttack;

    public Sprite canAttackSprite, cooldownAttackSprite;
    public Image attackImage;

    protected override void Start() {
        base.Start();
        melleeAttack = GetComponent<MelleeAttack>();
    }

    public override void Die() {
        base.Die();
        GameManager.gameManager.OpenMenu();
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
        if (melleeAttack.isAttacking)
            attackImage.sprite = cooldownAttackSprite;
        else
            attackImage.sprite = canAttackSprite;
    }

}
