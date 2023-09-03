using DG.Tweening;
using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float moveRightPos;
    [SerializeField] private float moveLeftPos;
    [SerializeField] private float randWaitTime;
    [SerializeField] private float moveTime;
    [SerializeField] private int liveNum;

    public int count = 0;

    private void Update()
    {
        if (GameManager.Instance.isAIMove)
            StartCoroutine(AIRandomMove());
    }

    IEnumerator AIRandomMove()  
    {
        yield return new WaitForSeconds(randWaitTime);

        switch (GameManager.Instance.quizCount)
        {
            case 1:
                Move_O();
                break;
            case 2:
                Move_X();
                break;
            case 3:
                Move_O();
                break;
            case 4:
                Move_X();
                break;
            case 5:
                if (liveNum == 5)
                    Move_X();
                else
                    Move_O();
                break;
            case 6:
                Move_X();
                break;
            case 7:
                if (liveNum == 7)
                    Move_X();
                Move_O();
                break;
            case 8:
                Move_X();
                break;
            case 9:
                if (liveNum == 9)
                    Move_O();
                else
                    Move_X();
                break;
            case 10:
                Move_O();
                break;
            case 11:
                if (liveNum == 11)
                    Move_O();
                else
                    Move_X();
                break;
            case 12:
                if (liveNum == 12)
                    Move_O();
                else
                    Move_X();
                break;
        }
    }

    public void Move_X()
    {
        while(count < 1)
        {
            transform.DOMoveX(moveRightPos, moveTime).SetEase(Ease.OutQuad);
            GameManager.Instance.isAIMove = false;
            count++;
            Debug.Log(count);
        }
        Invoke("CountChange", 6f);
        Debug.Log(count);
    }

    public void Move_O()
    {
        while (count < 1)
        {
            transform.DOMoveX(moveLeftPos, moveTime).SetEase(Ease.OutQuad);
            GameManager.Instance.isAIMove = false;
            count++;
            Debug.Log(count);
        }
        Invoke("CountChange", 6f);
        Debug.Log(count);
    }

    private void CountChange()
    {
        count = 0;
    }
}
