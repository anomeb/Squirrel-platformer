using UnityEngine;
using System.Collections;

public class MelleeAttack : MonoBehaviour {

    public DealDamage attackCollider;

    Animator animator;

    public bool isAttacking = false;

    public void Start() {
        animator = GetComponent<Animator>();
    }

    public void Attack() { 
        if (!isAttacking) {
            isAttacking = true;

            animator.SetBool("IsAttacking", true);
        }
    }

    public void DealDamage() {
        attackCollider.Damage();
    }

    public void AllowAttack() {
        isAttacking = false;
        animator.SetBool("IsAttacking", false);
    }
}
