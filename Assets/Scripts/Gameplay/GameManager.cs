using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    private AudioSource audioSource;
    [SerializeField] private GameObject bossFightMusic;
    [SerializeField] private GameObject levelMusic;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip winSound;

    [SerializeField] private HpScript player;
    [SerializeField] private HpScript boss;

    private void Start()
    {
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (player.curretHp <= 0)
            PlayerDeath();

        if (boss.curretHp <= 0 && boss.gameObject.activeInHierarchy)
            BossDeath();
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
