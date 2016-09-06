using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterTrigger : LayerCollisionList {

    public MyCharacterController controller;

    void FixedUpdate() {
        if (list.Count == 0)
            controller.isInTree = false;
        else controller.isInTree = true;
    }

    
}
