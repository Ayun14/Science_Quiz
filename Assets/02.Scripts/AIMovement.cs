using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float moveRightPos;
    [SerializeField] private float moveLeftPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Moveleft(); // 테스트 Input

        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight(); // 테스트 Input
    }

    private void RandomMove()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
            MoveRight();
        else if (rand == 1)
            Moveleft();
    }

    public void MoveRight()
    {
        float randTime = Random.Range(0.7f, 1.5f);
        transform.DOMoveX(moveRightPos, randTime).SetEase(Ease.OutQuad);
    }

    public void Moveleft()
    {
        float randTime = Random.Range(0.7f, 1.5f);
        transform.DOMoveX(moveLeftPos, randTime).SetEase(Ease.OutQuad);
    }
}
