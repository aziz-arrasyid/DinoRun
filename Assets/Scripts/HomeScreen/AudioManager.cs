using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    //Components Global
    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        float volumeDB = volume > 0.1f ? Mathf.Log10(volume) * 20 : -80f;
        audioMixer.SetFloat("MusicVolume", volumeDB);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        SetMusicVolume(musicVolume);
    }
}
