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

    private void Update()
    {
        if (GameManager.Instance.isQuizEnd)
            return;

        if (Input.GetKeyDown(KeyCode.A))
            Moveleft();

        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();

        if (transform.position.y >= 6)
        {
            GameManager.Instance.isLive = false;
            gameOverPanel.SetActive(true);

            switch (GameManager.Instance.quizCount)
            {
                case 1:
                    feedbackText.text = "�ڱ���� �ۿ��ϴ� ������ �ڱ����̶�� �Ѵ�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 2:
                    feedbackText.text = "�ڱ����� ������ S�ؿ��� N������ �帥��.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 3:
                    feedbackText.text = "���� �ڱ����� ������ ���� S�ؿ��� ���� N������ �帣�� ������ S���� �����̴�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 4:
                    feedbackText.text = "�������� �������� �ϱ� ������ ������ ������ �޼��� �ƴ� �������� �����հ����̴�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 5:
                    feedbackText.text = "������ ���³� ���� ���븦 ���� �������� �� �հ����� �ڱ����� ���� �̴�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 6:
                    feedbackText.text = "���� ������ �ڱ����� ����� �帣�� ������ ũ��� �ݺ���Ѵ�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 7:
                    feedbackText.text = "���� ������ �ڱ����� ����� �������κ����� �Ÿ��� �ݺ���Ѵ�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 8:
                    feedbackText.text = "���� ������ �ڱ����� ����� ������ ����� ���� ������ �ݺ���Ѵ�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 9:
                    feedbackText.text = "�ַ����̵��� ������ �帣�� ������ �������� �� �հ����̴�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 10:
                    feedbackText.text = "�ַ����̵� ���� �ڱ����� ����� ���� ���� �� ������ ���� ���� �帣�� ������ ����ϱ� �����̴�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 11:
                    feedbackText.text = "�ַ����̵� ���� �ڱ����� ����� ���� ���� �� ������ ���� ���� �帣�� ������ ����ϱ� �����̴�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 12:
                    feedbackText.text = "�ַ����̵��� ���� �ڱ����� ����� ���� ���� �� ������ ���� ���� ����ϱ� ������ 1m�� 100�� ���� �ͺ���" +
                        "1m�� 200�� ���� ���� �ڱ����� ���Ⱑ �� ũ��.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
                case 13:
                    feedbackText.text = "��ǥ���� ���÷� ����Ŀ, MRI, ������, ���ڼ� ���߱�, �ڱ� �λ� ���� ���� �ִ�.";
                    quizScoreText.text = "Q." + GameManager.Instance.quizCount;
                    break;
            }
        }

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
