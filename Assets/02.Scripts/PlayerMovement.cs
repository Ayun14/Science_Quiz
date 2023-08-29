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
        //DOMove(vector ���ϴ� ��ġ, float �̵� �ð�, bool ������);
        transform.DOMoveX(1.5f, 1f).SetEase(Ease.OutQuad);
    }

    public void Moveleft()
    {
        transform.DOMoveX(-1.5f, 1f).SetEase(Ease.OutQuad);
    }
}
