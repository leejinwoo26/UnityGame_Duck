using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInput : MonoBehaviour
{
    public event EventHandler onInteractAction;

    private PlayerInputAction playerInputAction;
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
        playerInputAction.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        onInteractAction?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 getMovementVectorNormalized()
    {
        Vector2 inputVec = playerInputAction.Player.Move.ReadValue<Vector2>();

        inputVec = inputVec.normalized;

        return inputVec;
    }
}
