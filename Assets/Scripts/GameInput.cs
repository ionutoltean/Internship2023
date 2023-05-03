using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playernPlayerInputActions;

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playernPlayerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    private void Awake()
    {
        playernPlayerInputActions = new PlayerInputActions();
        playernPlayerInputActions.Enable();
    }
}