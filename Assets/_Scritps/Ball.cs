using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveForce;
    public float maxVel;

    Rigidbody2D _rb;
    bool _isTriggered;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(_rb && _isTriggered)
        {
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -maxVel, maxVel), Mathf.Clamp(_rb.velocity.y, -maxVel, maxVel));
        }
    }

    public void Trigger()
    {
        if (_rb)
        {
            _isTriggered = true;
            _rb.isKinematic = false;
            _rb.AddForce(new Vector2(moveForce, moveForce));

            transform.SetParent(null);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(TagConsts.BRICK))
        {
            Brick brick = col.gameObject.GetComponent<Brick>();
            
                if (brick)
            {
                brick.Hit();
            }
        }


        if (col.gameObject.CompareTag(TagConsts.STICKER))
        {
            if (_rb.velocity.x > 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(new Vector2(moveForce, moveForce));
            }
            else if (_rb.velocity.x < 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(new Vector2(-moveForce, moveForce));
            }
        }

        if (col.gameObject.CompareTag(TagConsts.WALL_TOP))
        {
            if (_rb.velocity.x > 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(new Vector2(moveForce, -moveForce));
            }
            else if (_rb.velocity.x < 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(new Vector2(-moveForce, -moveForce));
            }
        }

        if (col.gameObject.CompareTag(TagConsts.WALL_LEFT))
        {
            if (_rb.velocity.y > 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(new Vector2(moveForce, moveForce));
            }
            else if (_rb.velocity.y < 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(new Vector2(moveForce, -moveForce));
            }
        }

        if (col.gameObject.CompareTag(TagConsts.WALL_RIGHT))
        {
            if (_rb.velocity.y > 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(new Vector2(-moveForce, moveForce));
            }
            else if (_rb.velocity.y < 0)
            {
                _rb.velocity = Vector2.zero;
                _rb.AddForce(new Vector2(-moveForce, -moveForce));
            }
        }
    }

    IEnumerator OpenGameoverDialog()
    {
        yield return new WaitForSeconds(1f);
        GameGUIManager.Ins.gameoverDialog.Show(true);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(TagConsts.DEAD_ZONE))
        {
            CineController.Ins.ShakeTrigger();
            AudioController.Ins.PlaySound(AudioController.Ins.hitDeadZone);
            StartCoroutine(OpenGameoverDialog());
            
        }
    }
}
