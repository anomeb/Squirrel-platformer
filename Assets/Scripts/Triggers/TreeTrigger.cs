using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeTrigger : LayerCollisionList {
    public MyCharacterController controller;

    void FixedUpdate() {
        if (list.Count == 0)
            controller.isBeforeTree = false;
        else controller.isBeforeTree = true;
    }
    
}
