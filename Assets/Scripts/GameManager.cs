using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HpScript player;
    public HpScript boss;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private AudioSource audioSource;
    public GameObject bossFightMusic;
    public GameObject levelMusic;
    public AudioClip gameOverSound;
    public AudioClip winSound;

    private void Start()
    {
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        player.onDeath += PlayerDeath;
        boss.onDeath += BossDeath;

    }

    public void Pause()
    {
        Time.timeScale = 0;
        bossFightMusic.SetActive(false);
        levelMusic.SetActive(false);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void PlayerDeath()
    {
        Pause();
        audioSource.clip = gameOverSound;
        audioSource.Play();
        gameOverPanel.SetActive(true);
    }

    public void BossDeath()
    {
        Pause();
        audioSource.clip = winSound;
        audioSource.Play();
        winPanel.SetActive(true);
    }


}
