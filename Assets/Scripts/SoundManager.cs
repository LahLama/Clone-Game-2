using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource sfxSource;
    public AudioSource footstepSource;
    public AudioSource bgmSource;

    public AudioClip walkSound;
    public AudioClip jumpSound;

    public AudioClip breakBrickSound;
    public AudioClip placeBrickSound;

    public AudioClip winSound;
    public AudioClip loseSound;

    public AudioClip bgMusic;

    private bool isWalking = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (bgmSource.isPlaying) return;
        bgmSource.clip = bgMusic;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void PlayWalk()
    {
        if (isWalking) return;
        isWalking = true;
        footstepSource.clip = walkSound;
        footstepSource.loop = true;
        footstepSource.Play();
    }

    public void StopWalk()
    {
        if (!isWalking) return;
        isWalking = false;
        footstepSource.Stop();
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    public void PlayBreakBrick()
    {
        sfxSource.PlayOneShot(breakBrickSound);
    }

    public void PlayPlaceBrick()
    {
        sfxSource.PlayOneShot(placeBrickSound);
    }

    public void PlayWin()
    {
        StopWalk();
        sfxSource.PlayOneShot(winSound);
    }

    public void PlayLose()
    {
        StopWalk();
        sfxSource.PlayOneShot(loseSound);
    }
}