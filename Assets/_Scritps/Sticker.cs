using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticker : MonoBehaviour
{
    public float moveSpeed = 250;
    Rigidbody2D _rb;
    [SerializeField] protected float _limitPosX = 2;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        this.LimitPos();
    }
    private void FixedUpdate()
    {
        this.Move();
    }

    void Move()
    {
        if (!_rb) return;

        if (GamePadsController.Ins.CanMoveLeft)
        {
            _rb.velocity = Vector2.left * moveSpeed * Time.fixedDeltaTime;
        }else if (GamePadsController.Ins.CanMoveRight)
        {
            _rb.velocity = Vector2.right * moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    void LimitPos()
    {
        if (transform.position.x >= _limitPosX)
        {
            transform.position = new Vector3(_limitPosX, transform.position.y, transform.position.z);
        }else if (transform.position.x <= -_limitPosX)
        {
            transform.position = new Vector3(-_limitPosX, transform.position.y, transform.position.z);
        }
    }
}
