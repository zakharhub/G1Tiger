using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public static MusicManager Instance
    {
        get { return instance; }
    }

    private AudioSource audioSource;

    private bool isMusicPlaying = true;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>(); 
    }

    void Start()
    {
        ToggleMusic(); 
    }

    public void ToggleMusic()
    {
        isMusicPlaying = !isMusicPlaying;
        if (isMusicPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }

    public void SetMusicState(bool state)
    {
        isMusicPlaying = state;
        if (isMusicPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
