using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _rotateSpeed = 10;
    [SerializeField] private float playerSize = 10;
    [SerializeField] private float playerHeight = 2.5f;
    [SerializeField] private GameInput _gameInput;
    private bool _isWalking;


    // Update is called once per frame
    void Update()
    {
        float moveDistance = _moveSpeed * Time.deltaTime;
        var inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
            playerSize, moveDir, moveDistance);
        _isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _rotateSpeed);


        if (!canMove)
        {
            /// X
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                playerSize, moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
                Debug.Log("Should move on X");
            }
            else
            {
                //z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
                    playerSize, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                    Debug.Log("Should move on Z");
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDistance * moveDir;
        }
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}