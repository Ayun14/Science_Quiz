using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int quizCount = 0;

    [SerializeField] private TextMeshProUGUI quizText = null;
    [SerializeField] private TextMeshProUGUI timeCountText = null;
    private int timeCount = 5;

    [SerializeField] private TextMeshProUGUI stageText = null;

    [SerializeField] private GameObject startPanel = null;
    [SerializeField] private GameObject clearPanel = null;
    [SerializeField] private GameObject introducePanel = null;
    [SerializeField] private GameObject quizPanel = null;

    [SerializeField] private GameObject oImage;
    [SerializeField] private GameObject xImage;

    public bool isLive = true;
    public bool isQuizEnd = false;
    public bool isAIMove = false;

    private SurikenSpawner surikenSpawner;
    private AIMovement aiMovement;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        surikenSpawner = FindObjectOfType<SurikenSpawner>();
        aiMovement = FindObjectOfType<AIMovement>();

        oImage.SetActive(false);
        xImage.SetActive(false);

        introducePanel.SetActive(false);
        startPanel.SetActive(true);
        quizPanel.SetActive(false);
        clearPanel.SetActive(false);

        quizCount = 0;
    }

    public void StartButtonClick()
    {
        introducePanel.SetActive(false);

        StartCoroutine(StageChange());
    }

    public void IntroduceButtonClick()
    {
        introducePanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    public void RetryButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator StageChange() // �� ��° �������� �ٲٱ�, ����, �ؽ�Ʈ
    {
        if (!isLive)
            yield break;

        timeCount = 5;
        if (quizCount >= 14)
        {
            clearPanel.SetActive(true);
            yield break;
        }

        yield return new WaitForSeconds(2f);

        isQuizEnd = false;

        oImage.SetActive(true);
        oImage.transform.DOScale(1, 0.7f).SetEase(Ease.OutSine);
        xImage.SetActive(true);
        xImage.transform.DOScale(1, 0.7f).SetEase(Ease.OutSine);

        quizPanel.SetActive(true);
        quizPanel.transform.DOScale(1, 0.7f).SetEase(Ease.OutSine);

        isAIMove = true;

        quizCount++;
        switch (quizCount)
        {
            case 1:
                quizText.text = "�ڱ���� �ۿ��ϴ� ������ �ڱ����̶�� �Ѵ�."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 2:
                quizText.text = "�ڱ����� ������ S���̴�."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 3:
                quizText.text = "���� �ڱ����� ���� ������ S���̴�."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 4:
                quizText.text = "���� ������ ������ ��Ÿ���� ������ �帣�� ������ �޼��� ���� �հ����̴�."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 5:
                quizText.text = "���� ������ ������ ��Ÿ���� �ڱ����� ������ �������� �� �հ����̴�."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 6:
                quizText.text = "���� ������ �ڱ����� ����� ������ �帣�� ������ ũ��� �ݺ���Ѵ�."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 7:
                quizText.text = "���� ������ �ڱ����� ����� �������κ����� �Ÿ��� �ݺ�� �Ѵ�."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 8:
                quizText.text = "���� ������ �ڱ����� ����� ������ ����� ���� ������ ����Ѵ�."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 9:
                quizText.text = "�ַ����̵��� ������ �帣�� ������ ������ ��Ÿ���� �� ������ �帣�� ������ ������ ���� �հ����̴�."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 10:
                quizText.text = "�ַ����̵带 1m�� 100�� ���� �Ͱ� 2m�� 200�� ���� ���� �ڱ����� ����� ����."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 11:
                quizText.text = "�ַ����̵� ���� �ڱ����� ����� ���� ���̿� ������� �ʰ� ������ ���� ���� �帣�� ������ ����Ѵ�."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 12:
                quizText.text = "�ַ����̵带 1m�� 100�� ���� �Ͱ� 1m�� 200�� ���� ���� �ڱ����� ����� ����."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 13:
                quizText.text = "�ϻ��Ȱ������ �ڱ����� ����� �پ��� ������ ��ǥ���� ���� ����Ŀ, MRI ���� �ִ�."; // O
                stageText.text = "Q." + quizCount;
                break;
        }

        while (timeCount >= 0)
        {
            yield return new WaitForSeconds(1f);
            timeCountText.text = timeCount + "";
            timeCount--;
        }

        quizPanel.SetActive(false);
        quizPanel.transform.DOScale(0, 0.7f).SetEase(Ease.OutSine);
        oImage.SetActive(false);
        oImage.transform.DOScale(0, 0.7f).SetEase(Ease.OutSine);
        xImage.SetActive(false);
        xImage.transform.DOScale(0, 0.7f).SetEase(Ease.OutSine);

        StartCoroutine(StageEnd());
    }

    IEnumerator StageEnd() // Ʋ�� ����� �װ� ���� ��������
    {
        if (!isLive)
            yield break;

        isQuizEnd = true;
        isAIMove = false;

        switch (quizCount)
        {
            case 1:
                surikenSpawner.X_SuikenSpawn();
                break;
            case 2:
                surikenSpawner.O_SuikenSpawn();
                break;
            case 3:
                surikenSpawner.X_SuikenSpawn();
                break;
            case 4:
                surikenSpawner.O_SuikenSpawn();
                break;
            case 5:
                surikenSpawner.X_SuikenSpawn();
                break;
            case 6:
                surikenSpawner.O_SuikenSpawn();
                break;
            case 7:
                surikenSpawner.X_SuikenSpawn();
                break;
            case 8:
                surikenSpawner.O_SuikenSpawn();
                break;
            case 9:
                surikenSpawner.O_SuikenSpawn();
                break;
            case 10:
                surikenSpawner.X_SuikenSpawn();
                break;
            case 11:
                surikenSpawner.O_SuikenSpawn();
                break;
            case 12:
                surikenSpawner.O_SuikenSpawn();
                break;
            case 13:
                surikenSpawner.X_SuikenSpawn();
                break;
        }
        yield return new WaitForSeconds(2);

        StartCoroutine(StageChange());
    }
}
