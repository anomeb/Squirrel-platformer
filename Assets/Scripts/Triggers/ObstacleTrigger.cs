using UnityEngine;
using System.Collections;

public class ObstacleTrigger : LayerCollisionList {

    public MyCharacterController controller;

    void FixedUpdate() {
        if (list.Count > 0)
            controller.isBeforeObstacle = true;
        else controller.isBeforeObstacle = false;
    }
}
