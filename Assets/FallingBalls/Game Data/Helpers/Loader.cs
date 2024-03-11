using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 游戏综合管理 + 实现
/// </summary>
public class Loader : MonoBehaviour
{
    public static Loader instance;

    [SerializeField] int lastScene = 10;
    int lastLevelIndex = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        lastLevelIndex = PlayerPrefs.GetInt("LastLevel", 1);

        LastLevel();
    }

    public void LastLevel()
    {
        if (lastLevelIndex > lastScene)
        {
            SceneManager.LoadScene(11);
        }
        else
            SceneManager.LoadScene(lastLevelIndex);
    }
    /// <summary>
    /// 进入下一关
    /// </summary>
    public void NextLevel()
    {
        if (GameManager.Instance.level + 1 > lastScene)
        {
            SceneManager.LoadScene(11);
        }
        else
            SceneManager.LoadScene(GameManager.Instance.level + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
