using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 背景音乐管理器 — 跨场景持久化，支持播放/停止切换
/// </summary>
public class BGMManager : MonoBehaviour
{
    [Header("BGM设置")]
    [SerializeField] private AudioClip bgmClip;
    [Range(0f, 1f)] [SerializeField] private float volume = 0.5f;

    [Header("UI控制（可选绑定）")]
    [SerializeField] private Button toggleButton;
    [SerializeField] private Text toggleButtonText;

    private AudioSource audioSource;
    private bool isPlaying = true;

    private static BGMManager instance;

    void Awake()
    {
        // 单例模式：确保跨场景只有一个 BGM 管理器
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // 获取或添加 AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // 配置 BGM
        audioSource.clip = bgmClip;
        audioSource.loop = true;
        audioSource.volume = volume;
        audioSource.Play();
        isPlaying = true;

        // 绑定 UI 按钮
        if (toggleButton != null)
            toggleButton.onClick.AddListener(ToggleBGM);

        UpdateButtonText();
    }

    public void ToggleBGM()
    {
        if (isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();

        isPlaying = !isPlaying;
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        if (toggleButtonText != null)
            toggleButtonText.text = isPlaying ? "音乐：开" : "音乐：关";
    }
}
