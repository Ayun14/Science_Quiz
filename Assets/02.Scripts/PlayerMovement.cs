using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Moveleft();

        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();
    }

    public void MoveRight()
    {
        //DOMove(vector 원하는 위치, float 이동 시간, bool 스냅핑);
        transform.DOMoveX(1.5f, 1f).SetEase(Ease.OutQuad);
    }

    public void Moveleft()
    {
        transform.DOMoveX(-1.5f, 1f).SetEase(Ease.OutQuad);
    }
}
