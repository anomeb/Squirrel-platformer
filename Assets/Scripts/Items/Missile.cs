using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : PickUp {
    public bool isDestroyed = false;
    public float ignoreTime = 0.5f;
    public int damage = 1;
    public float minDamageSpeed = 100.0f;
    public List<Collider2D> ignoreList = new List<Collider2D>();
    Collider2D thisCollider;
   // Rigidbody2D rigidBody;

    void Start() {
        thisCollider = GetComponent<Collider2D>();
   //     rigidBody = GetComponent<Rigidbody2D>();
    }

    public void IgnoreCollision(List<Collider2D> list) {
        foreach (Collider2D col in list) {
            Physics2D.IgnoreCollision(thisCollider, col);
            ignoreList.Add(col);
            Invoke("StopIgnoreCollision", ignoreTime);
        }
    }

    void StopIgnoreCollision() {
        foreach (Collider2D col in ignoreList) {
            Physics2D.IgnoreCollision(thisCollider, col, false);
        }
        ignoreList.Clear();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.relativeVelocity.sqrMagnitude > minDamageSpeed)
       // if (collision.relativeVelocity.sqrMagnitude > minDamageSpeed) 
                {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health)
                health.Damage(damage);
        }
	}
}
