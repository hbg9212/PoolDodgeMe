using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public int currentStage = 1; // 현재 스테이지
    public int currentLevel = 1; // 현재 레벨
    public float levelDuration = 60.0f; // 레벨 지속 시간
    private float timeElapsed = 0.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        UpdateLevel();
    }

    void UpdateLevel()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= levelDuration)
        {
            // 60초가 지나면 레벨을 1 증가시키고 다음 레벨에 필요한 설정을 수행합니다.
            currentLevel++;
            timeElapsed = 0.0f;
        }
    }

    // 다른 스크립트에서 StageManager.Instance.currentStage와 StageManager.Instance.currentLevel로 현재 스테이지와 레벨에 접근할 수 있습니다.
}
