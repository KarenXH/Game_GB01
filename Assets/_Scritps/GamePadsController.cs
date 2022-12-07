using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadsController : Singleton<GamePadsController>
{
    public bool isOnMobile;
    bool _canMoveLeft;
    bool _canMoveRight;

    public bool CanMoveLeft { get => _canMoveLeft; set => _canMoveLeft = value; }
    public bool CanMoveRight { get => _canMoveRight; set => _canMoveRight = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    void PCInputHandle()
    {
        _canMoveLeft = Input.GetAxisRaw("Horizontal") <0 ? true : false;
        _canMoveRight = Input.GetAxisRaw("Horizontal") > 0 ? true : false;
    }

    private void Update()
    {
        if (!isOnMobile)
            this.PCInputHandle();
    }
}
