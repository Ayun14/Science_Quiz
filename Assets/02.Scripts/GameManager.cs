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

    IEnumerator StageChange() // 몇 번째 문제인지 바꾸기, 구분, 텍스트
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
                quizText.text = "자기력이 작용하는 공간을 자기장이라고 한다."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 2:
                quizText.text = "자기장의 방향은 S극이다."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 3:
                quizText.text = "지구 자기장의 방향 남쪽은 S극이다."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 4:
                quizText.text = "직선 도선을 손으로 나타내면 전류가 흐르는 방향은 왼손의 엄지 손가락이다."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 5:
                quizText.text = "직선 도선을 손으로 나타내면 자기장의 방향은 오른손의 네 손가락이다."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 6:
                quizText.text = "직선 도선의 자기장의 세기는 도선에 흐르는 전류의 크기와 반비례한다."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 7:
                quizText.text = "직선 도선의 자기장의 세기는 도선으로부터의 거리와 반비례 한다."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 8:
                quizText.text = "원형 도선의 자기장의 세기는 도선이 만드는 원의 지름에 비례한다."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 9:
                quizText.text = "솔레노이드의 전류가 흐르는 방향을 손으로 나타냈을 때 전류가 흐르는 방향은 오른손 엄지 손가락이다."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 10:
                quizText.text = "솔레노이드를 1m씩 100번 감은 것과 2m씩 200번 감은 것의 자기장의 세기는 같다."; // O
                stageText.text = "Q." + quizCount;
                break;
            case 11:
                quizText.text = "솔레노이드 내부 자기장의 세기는 단위 길이에 상관하지 않고 도선의 감은 수와 흐르는 전류에 비례한다."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 12:
                quizText.text = "솔레노이드를 1m씩 100번 감은 것과 1m씩 200번 감은 것의 자기장의 세기는 같다."; // X
                stageText.text = "Q." + quizCount;
                break;
            case 13:
                quizText.text = "일상생활에서의 자기장이 생기는 다양한 현상의 대표적인 것은 스피커, MRI 등이 있다."; // O
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

    IEnumerator StageEnd() // 틀린 사람들 죽고 다음 스테이지
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
