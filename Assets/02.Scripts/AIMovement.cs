using DG.Tweening;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float moveRightPos;
    [SerializeField] private float moveLeftPos;

    private int count = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Moveleft(); // 테스트 Input

        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight(); // 테스트 Input

        if (GameManager.Instance.isAIMove)
            AIRandomMove();
    }

    public void AIRandomMove()  
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
            MoveRight();
        else if (rand == 1)
            Moveleft();
    }

    public void MoveRight()
    {
        if (!GameManager.Instance.isLive)
            return;

        while(count < 1)
        {
            float randTime = Random.Range(0.7f, 1.5f);
            transform.DOMoveX(moveRightPos, randTime).SetEase(Ease.OutQuad);
            count++;
        }
    }

    public void Moveleft()
    {
        if (!GameManager.Instance.isLive)
            return;

        while (count < 1)
        {
            float randTime = Random.Range(0.7f, 1.5f);
            transform.DOMoveX(moveLeftPos, randTime).SetEase(Ease.OutQuad);
            count++;
        }
    }
}
