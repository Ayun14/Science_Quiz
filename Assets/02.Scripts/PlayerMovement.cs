using DG.Tweening;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel = null;

    [SerializeField] private TextMeshProUGUI feedbackText = null;
    [SerializeField] private TextMeshProUGUI quizScoreText = null;

    [SerializeField] private AudioSource[] audioSource;
    // 0���� ���� ���� 1���� Ʋ�� ����

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.isLive == false) // �׾�����
            LiveCheak();

        if (GameManager.Instance.isQuizEnd) // ��� ������ �������� X
            return;

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

    public void RightSound()
    {
        switch (GameManager.Instance.quizCount)
        {
            // 0���� ũ�� X ������ O
            case 1: // o
                if (transform.position.x < 0)
                    audioSource[0].Play();
                else
                    audioSource[1].Play();
                break;
            case 2: // x
                if (transform.position.x < 0)
                    audioSource[1].Play();
                else
                    audioSource[0].Play();
                break;
            case 3: // o
                if (transform.position.x < 0)
                    audioSource[0].Play();
                else
                    audioSource[1].Play();
                break;
            case 4: // x
                if (transform.position.x < 0)
                    audioSource[1].Play();
                else
                    audioSource[0].Play();
                break;
            case 5: // o
                if (transform.position.x < 0)
                    audioSource[0].Play();
                else
                    audioSource[1].Play();
                break;
            case 6: // x
                if (transform.position.x < 0)
                    audioSource[1].Play();
                else
                    audioSource[0].Play();
                break;
            case 7: // o
                if (transform.position.x < 0)
                    audioSource[0].Play();
                else
                    audioSource[1].Play();
                break;
            case 8: // x
                if (transform.position.x < 0)
                    audioSource[1].Play();
                else
                    audioSource[0].Play();
                break;
            case 9: // x
                if (transform.position.x < 0)
                    audioSource[1].Play();
                else
                    audioSource[0].Play();
                break;
            case 10: // o
                if (transform.position.x < 0)
                    audioSource[0].Play();
                else
                    audioSource[1].Play();
                break;
            case 11: // x
                if (transform.position.x < 0)
                    audioSource[1].Play();
                else
                    audioSource[0].Play();
                break;
            case 12: // x
                if (transform.position.x < 0)
                    audioSource[1].Play();
                else
                    audioSource[0].Play();
                break;
            case 13: // o
                if (transform.position.x < 0)
                    audioSource[0].Play();
                else
                    audioSource[1].Play();
                break;
        }

    }

    public void LiveCheak()
    {
        gameOverPanel.SetActive(true);
        BackgroundAudio.Instance.BgmOff();

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
