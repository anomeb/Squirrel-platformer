using UnityEngine;
using System.Collections.Generic;

public class Shooter : MonoBehaviour {

    public GameObject missilePrefab;
    public Transform missilePosition;
    public GameObject missileParent;
    public float force = 5.0f;
    public float torque = 0.1f;
    public float throwAngle = 0.0f;
    [HideInInspector]
    public bool isLookingAtRight = true;
    public int missilesQuantity = 5;
    public int maxMissilesQuantity = 5;
    public List<Collider2D> colList = new List<Collider2D>();

    public bool isLimitedAmmunition = true;

    

    // Use this for initialization
    void Start() {
    }


    public void Attack() {

        if (!isLimitedAmmunition || missilesQuantity > 0) {
            Quaternion rotation;
            if (isLookingAtRight)
                rotation = Quaternion.FromToRotation(Vector3.down, Vector3.right);
            else rotation = Quaternion.FromToRotation(Vector3.down, Vector3.left);

            GameObject newMissile = Instantiate(missilePrefab, missilePosition.position, rotation) as GameObject;
            newMissile.GetComponent<Missile>().IgnoreCollision(colList);
            if (!isLookingAtRight) {
                Vector3 scale = newMissile.transform.localScale;
                scale.x *= -1;
                newMissile.transform.localScale = scale;
                newMissile.transform.Rotate(Vector3.forward, - throwAngle);
            }
            else
                newMissile.transform.Rotate(Vector3.forward, throwAngle);

            newMissile.transform.parent = missileParent.transform;
            Rigidbody2D missileRB = newMissile.GetComponent<Rigidbody2D>();
            missileRB.AddForce(-newMissile.transform.up * force, ForceMode2D.Impulse);
            missileRB.AddTorque(torque, ForceMode2D.Impulse);


            if (isLimitedAmmunition)
                --missilesQuantity;
        }
        if (missilesQuantity < 0)
            missilesQuantity = 0;
    }

}
