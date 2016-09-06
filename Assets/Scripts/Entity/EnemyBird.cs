using UnityEngine;
using System.Collections;

public class EnemyBird : Bird {
    MelleeAttack mellee;
    protected override void Start() {
        base.Start();
        mellee = GetComponent<MelleeAttack>();
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
        Entity entity = target.GetComponent<Entity>();
        if (mellee.attackCollider.list.Contains(entity))
            mellee.Attack();
    }
}
