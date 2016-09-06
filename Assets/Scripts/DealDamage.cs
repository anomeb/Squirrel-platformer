using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DealDamage : CollisionContainer<Entity> {
    public Health.Group ignoringGroup;
    public int damageAmount = 1;
    public float attackForce = 50.0f;
    public MyCharacterController controller;

    // Use this for initialization
    void Start() {
    }

    public void Damage() {
        foreach(Entity entity in list)
            if (entity.health && entity.health.group != ignoringGroup) {
                entity.health.Damage(damageAmount);
                Rigidbody2D rigidBody = entity.health.gameObject.GetComponent<Rigidbody2D>();
                if (rigidBody) {
                    if (controller.isFacingRight)
                        rigidBody.AddForce(new Vector2(attackForce, 0), ForceMode2D.Force);
                    else
                        rigidBody.AddForce(new Vector2(- attackForce, 0), ForceMode2D.Force);
                }
            }
       
    }
}