using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MyCharacterController {

    public float minTreeFallSensitivity = 0.8f;
    public float minJumpSensitivity = 0.4f;
    public float minMoveSensitivity = 0.2f;
    public float platformFallSensitivity = 0.35f;

    public Sprite treesEnabled, treesDisabled;
    public Image treeImage;

    public SpriteRenderer playerSprite;

    public override void FixedUpdate() {
        Vector2 input = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"));
        if (input.y > minJumpSensitivity) {
            TryHangOnTree();
            TryJump();
        }

        Vector2 newInput = input;
        if (Mathf.Abs(input.x) < minMoveSensitivity)
            newInput.x = 0;
        if (Mathf.Abs(input.y) < minMoveSensitivity)
            newInput.y = 0;
        MoveX(newInput.x);


        if (isOnTree && Mathf.Abs(input.x) < minTreeFallSensitivity && Mathf.Abs(input.y) < minJumpSensitivity)
            rigidBody.velocity = Vector2.zero;
        if (input.y < - platformFallSensitivity) {
            DisablePlatformCollision();
        }

        base.FixedUpdate();

    }

    public override void IgnoreTree() {
        base.IgnoreTree();
        treeImage.sprite = treesDisabled;
    }

    public override void UnIgnoreTree() {
        base.UnIgnoreTree();
        treeImage.sprite = treesEnabled;
    }
}