using UnityEngine;
using System.Collections;

public class Enemy : Entity {

    MyCharacterController controller;

    Vision vision;

    public Transform target;
    public float maxTargetDistance = 1.0f;
    Shooter shooter;
    MelleeAttack mellee;
    float spottingTime = 0.0f;
    float lostTime = 2.0f;
    Entity targetEntity;

    protected override void Start() {
        base.Start();
        vision = GetComponentInChildren<Vision>();
        shooter = GetComponent<Shooter>();
        controller = GetComponent<MyCharacterController>();
        mellee = GetComponent<MelleeAttack>();
        InvokeRepeating("EnemyAttack", 1.0f, 1.0f);
    }
    override public void  FixedUpdate() {
        base.FixedUpdate();
        controller.MoveX(0.0f);
        if (Time.time - spottingTime > lostTime) {
            targetEntity = null;
            target = null;
        }
        if (!target) {
            if (vision.visibleEntities.Count > 0) {
                targetEntity = vision.visibleEntities[0];
                if (targetEntity) {
                    target = targetEntity.transform;
                    spottingTime = Time.time;
                }
            }
            else 
                if (!IsInvoking("DoMove"))
                InvokeRepeating("DoMove", lostTime * 2, lostTime * 2);
        }
        if (vision.visibleEntities.Contains(targetEntity))
            spottingTime = Time.time;
        

        if (target) {
            CancelInvoke("DoMove");
            if (Mathf.Abs(target.position.x - transform.position.x) > maxTargetDistance) {
                if (target.transform.position.x > transform.position.x)
                    controller.MoveX(1.0f);
                else
                    controller.MoveX(-1.0f);

            }
            if (target.transform.position.y - transform.position.y > maxTargetDistance) {
                controller.TryHangOnTree();
                controller.TryJump();
            }
        }

        if (controller.isBeforeObstacle && target) {
            controller.TryJump();
        }
    }
    
    void DoMove() {
        if (controller.isFacingRight)
            controller.MoveX(-1.0f);
        else
            controller.MoveX(1.0f);
    }

    void EnemyAttack() {
        if (targetEntity)
            if (mellee.attackCollider.list.Contains(targetEntity))
                mellee.Attack();
            else {
                if (shooter)
                    shooter.Attack();
            }
    }
}
