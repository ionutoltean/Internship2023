using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _rotateSpeed = 10;
    private bool _isWalking;

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey((KeyCode.W)))
        {
            inputVector.y += 1 * Time.deltaTime;
        }

        if (Input.GetKey((KeyCode.S)))
        {
            inputVector.y -= 1 * Time.deltaTime;
        }

        if (Input.GetKey((KeyCode.D)))
        {
            inputVector.x += 1 * Time.deltaTime;
        }

        if (Input.GetKey((KeyCode.A)))
        {
            inputVector.x -= 1 * Time.deltaTime;
        }

        inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        _isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * _rotateSpeed);
        transform.position += _moveSpeed * moveDir;
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}