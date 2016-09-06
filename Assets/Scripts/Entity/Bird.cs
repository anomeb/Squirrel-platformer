using UnityEngine;
using System.Collections;

public class Bird : Entity {
    public Transform target;
    public Vector2 speed;
    public float maxDistance = 1.0f;

    bool isLookingRight = true;

    Rigidbody2D rigidBody;
	// Use this for initialization
	override protected void Start () {
        base.Start();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public override void FixedUpdate() {
        base.FixedUpdate();
        if (target) {
            Vector2 newVelocity = Vector2.zero;
            if (Mathf.Abs(target.position.x - transform.position.x) > maxDistance) {

                if (target.transform.position.x > transform.position.x)
                    newVelocity.x = speed.x;
                else
                    newVelocity.x = -speed.x;
            }
            if (Mathf.Abs(target.position.y - transform.position.y) > maxDistance) {
                if (target.transform.position.y - transform.position.y > maxDistance)

                    newVelocity.y = speed.y;
                else
                    newVelocity.y = -speed.y;
            }
            rigidBody.velocity = newVelocity;
        }
        if (isLookingRight && rigidBody.velocity.x < 0)
            Flip();
        if (!isLookingRight && rigidBody.velocity.x > 0)
            Flip();
    }

    void Flip() {
        isLookingRight = !isLookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
