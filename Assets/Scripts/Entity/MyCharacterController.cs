using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MyCharacterController : MonoBehaviour {
    
    public float moveForce = 0.5f;
    public float jumpForce = 1.0f;
    public float jumpCooldown = 0.2f;
    public float startSpeed = 2.0f;
    public float jumpFading = 0.7f;

    public Transform groundPosition;
    public float groundRadius;
    public LayerMask groundMask;

    public bool isInTree = false;
    public bool isBeforeTree = false;
    public bool isBeforeObstacle = false;
    protected bool isOnTree = false;
    public bool isFacingRight = true;
    protected bool isJumping = false;
    protected bool isIgnoringTrees = false;

    protected Collider2D mainCollider;
    [SerializeField] protected Collider2D sideCollider;
    protected Animator animator;
    protected Rigidbody2D rigidBody;
    protected Shooter shooter;
    protected TreeTrigger treeTrigger;
    protected CharacterTrigger characterTrigger;

    List<Collider2D> ignoringTrees = new List<Collider2D>();

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        shooter = GetComponent<Shooter>();
        mainCollider = GetComponent<Collider2D>();
        treeTrigger = GetComponentInChildren<TreeTrigger>();
        characterTrigger = GetComponentInChildren<CharacterTrigger>();
        IgnoreTree();
    }

    public void SwitchIgnoringTrees() {
        if (isIgnoringTrees)
            UnIgnoreTree();
        else IgnoreTree();
    }
    //to do check near tree
    public virtual void IgnoreTree() {
        isIgnoringTrees = true;
        foreach (Collider2D col in treeTrigger.list) {
            Physics2D.IgnoreCollision(col, mainCollider, true);
            Physics2D.IgnoreCollision(col, sideCollider, true);
            ignoringTrees.Add(col);
        }
        foreach (Collider2D col in characterTrigger.list) {
            Physics2D.IgnoreCollision(col, mainCollider, true);
            Physics2D.IgnoreCollision(col, sideCollider, true);
            ignoringTrees.Add(col);
        }
    }

    public virtual void UnIgnoreTree() {
        isIgnoringTrees = false;
        foreach (Collider2D col in ignoringTrees) {
            Physics2D.IgnoreCollision(col, mainCollider, false);
            Physics2D.IgnoreCollision(col, sideCollider, false);
        }
        ignoringTrees.Clear();
        
    }

    protected virtual void CheckTreeDetaching() {
        if (!isBeforeTree)
            TreeDetach();
    }

    public void TreeDetach() {
        isOnTree = false;
        IgnoreTree();
    }

    public virtual void FixedUpdate() {
        CheckTreeDetaching();
        if (isIgnoringTrees)
            IgnoreTree();
        SetAnimatorValues();
    }

    protected void SetAnimatorValues() {
        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
    }

    public void TryHangOnTree() {
        if (isBeforeTree && !isInTree) {
            isOnTree = true;
            UnIgnoreTree();
        }
    }

    protected void DisablePlatformCollision() {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), true);
        Invoke("EnablePlatformCollision", 0.5f);
    }

    protected void EnablePlatformCollision() {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), false);
    }

    public void MoveX(float amount) {

        if (amount < 0 && isFacingRight)
            Flip();
        if (amount > 0 && !isFacingRight)
            Flip();

        rigidBody.velocity = new Vector2(amount * moveForce, rigidBody.velocity.y);

    }

    public void TryJump() {
        if (!isJumping) {
            if (isOnTree)
                Jump();
            if (IsGrounded()) {
                Jump();
            }
        }
    }

    protected void AllowJump() {
        isJumping = false;
    }

    protected bool IsGrounded() {
        return Physics2D.OverlapCircle(groundPosition.position, groundRadius, groundMask);
    }

    protected void Jump() {
        isJumping = true;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x * jumpFading, 0.0f);
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Invoke("AllowJump", jumpCooldown);
    }

    protected void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x = -scale.x;
        transform.localScale = scale;
        if (shooter)
            shooter.isLookingAtRight = isFacingRight;
    }



}
