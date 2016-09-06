using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public enum Group {
        Player,
        Enemy,
        Obstacle
    }
    public Group group;
    public int amount = 10;
    public int maxAmount = 10;
    public int regenerateHPAmount = 1;
    public float regenerateTime = 0;
    public bool isTakingDamageFromCollisions = true;
    public float damageImpulse = 10.0f;

    public GameObject healthBarPrefab;
    public float healthBarTime = 1.0f;

    Entity entity;
    GameObject healthBar;

    void Start() {
        amount = maxAmount;
        entity = GetComponent<Entity>();
        if (regenerateTime > 0.01)
            InvokeRepeating("Regenerate", regenerateTime, regenerateTime);
    }

    void Regenerate() {
        Heal(regenerateHPAmount);
    }

    public void Heal(int amount) {
        this.amount += amount;
        if (this.amount > maxAmount)
            this.amount = maxAmount;
    }

	public void Damage(int amount) {
        this.amount -= amount;
        if (this.amount < 0) this.amount = 0;

        if (!healthBar) {
            healthBar = Instantiate(healthBarPrefab, transform.position, transform.rotation) as GameObject;
            healthBar.transform.parent = transform;
            HealthBar HB = healthBar.GetComponent<HealthBar>();
            HB.health = this;
            HB.UpdateScale();
            Invoke("DestroyHealthBar", healthBarTime);
        }
        else
            CancelInvoke("DestroyHealthBar");

        if (this.amount == 0)
            Die();
    }

    void DestroyHealthBar() {
        Destroy(healthBar);
        healthBar = null;
    }

    public void Die() {
        if (healthBar)
            DestroyHealthBar();
        if (entity)
            entity.Die();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (isTakingDamageFromCollisions) {
            Rigidbody2D rigidBody = collision.gameObject.GetComponentInParent<Rigidbody2D>();
            if (rigidBody) {
                // float impulse = Vector2.Dot(collision.relativeVelocity, collision.contacts[0].normal) * rigidBody.mass;
                float impulse = Mathf.Abs( Vector2.SqrMagnitude(collision.relativeVelocity) ) * rigidBody.mass;
                if (impulse > damageImpulse) {
                    Damage(1);
                }
            }
        }
    }
}
