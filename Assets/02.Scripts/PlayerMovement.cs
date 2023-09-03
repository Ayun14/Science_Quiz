using DG.Tweening;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel = null;

    [SerializeField] private TextMeshProUGUI feedbackText = null;
    [SerializeField] private TextMeshProUGUI quizScoreText = null;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.isLive == false) // 죽었을때
            LiveCheak();

        if (Input.GetKeyDown(KeyCode.Space)) // 개발자용 클리어 키
            GameManager.Instance.quizCount = 14;

        if (GameManager.Instance.isQuizEnd) // 퀴즈가 끝나면 움직이지 X
            return;

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

    public void LiveCheak()
    {
        gameOverPanel.SetActive(true);

        switch (GameManager.Instance.quizCount)
        {
            case 1:
                feedbackText.text = "자기력이 작용하는 공간을 자기장이라고 한다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 2:
                feedbackText.text = "자기장의 방향은 S극에서 N극으로 흐른다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 3:
                feedbackText.text = "지구 자기장의 방향은 남쪽 S극에서 북쪽 N극으로 흐르기 때문에 S극은 남극이다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 4:
                feedbackText.text = "오른손을 기준으로 하기 때문에 전류의 방향은 왼손이 아닌 오른손의 엄지손가락이다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 5:
                feedbackText.text = "손으로 나태내 보면 막대를 감은 오른손의 네 손가락이 자기장의 방향 이다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 6:
                feedbackText.text = "직선 도선의 자기장의 세기는 흐르는 전류의 크기와 반비례한다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 7:
                feedbackText.text = "직선 도선의 자기장의 세기는 도선으로부터의 거리에 반비례한다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 8:
                feedbackText.text = "원형 도선의 자기장의 세기는 도선이 만드는 원의 지름에 반비례한다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 9:
                feedbackText.text = "솔레노이드의 전류가 흐르는 방향은 오른손의 네 손가락이다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 10:
                feedbackText.text = "솔레노이드 내부 자기장의 세기는 단위 길이 당 도선의 감은 수와 흐르는 전류에 비례하기 때문이다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 11:
                feedbackText.text = "솔레노이드 내부 자기장의 세기는 단위 길이 당 도선의 감은 수와 흐르는 전류에 비례하기 때문이다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 12:
                feedbackText.text = "솔레노이드의 내부 자기장의 세기는 단위 길이 당 도선의 감은 수와 비례하기 때문에 1m를 100번 감은 것보다" +
                    "1m를 200번 감은 것이 자기장의 세기가 더 크다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
            case 13:
                feedbackText.text = "대표적인 예시로 스피커, MRI, 전동기, 전자석 가중기, 자기 부상 열차 등이 있다.";
                quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                break;
        }
    }
}
