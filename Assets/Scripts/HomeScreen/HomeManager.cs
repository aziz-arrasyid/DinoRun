using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
    [SerializeField] GameObject panelAudio;
    [SerializeField] private Slider musicSlider;

    //variable
    private float tempMusicVolume;
    private void Awake()
    {
        panelAudio.SetActive(false);
    }
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void OpenPanelAudio()
    {
        panelAudio.SetActive(true);
    }

    public void ApplyAudio()
    {
        panelAudio.SetActive(false);
        AudioManager.Instance.SetMusicVolume(tempMusicVolume);
    }

    private void Start()
    {
        tempMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);

        musicSlider.value = tempMusicVolume;
        musicSlider.onValueChanged.AddListener(value => tempMusicVolume = value);
    }

    public void QuitApplication()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
