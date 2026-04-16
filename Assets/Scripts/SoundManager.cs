using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
    [SerializeField] Slider volumeSlider;
    private AudioSource musicSource;

    void Awake() {
        musicSource = GetComponent<AudioSource>();

        // Set default if first time
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1f);
        }
        
        Load();

        // Connect slider to function
        if (volumeSlider != null) {
            volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        }
    }

    public void ChangeVolume() {
        // DIRECT CONTROL: Talk to the music source, not the global listener
        if (musicSource != null) {
            musicSource.volume = volumeSlider.value;
        }
        
        Save();
    }

    private void Load() {
        float savedVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        
        // Apply directly to the source
        if (musicSource != null) {
            musicSource.volume = savedVolume;
            if (!musicSource.isPlaying) musicSource.Play();
        }

        if (volumeSlider != null) {
            volumeSlider.SetValueWithoutNotify(savedVolume);
        }
    }

    private void Save() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}