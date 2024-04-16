using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Audio Sources
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource SFXSource;

    // Background Music
    public AudioClip backgroundMusic1;
    public AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;

    
    // Menu and UI Sounds
    public AudioClip menuMusic;
    public AudioClip buttonClick;
    public AudioClip gameOver;
    public AudioClip gameWin;
    
    // Player
    public AudioClip playerJump;
    public AudioClip playerDeath;
    public AudioClip playerHurt;
    public AudioClip playerAttack1;
    public AudioClip playerAttack2;
    public AudioClip playerCollect;
    // Enemy Sounds
    public AudioClip enemyAttack;
    public AudioClip enemyDeath;

    public AudioClip explosion;

    //array of background music
    public AudioClip[] backgroundMusic;

    public AudioClip[] playerSteps;

    public AudioClip playerSteps1;
    public AudioClip playerSteps2;
    public AudioClip playerSteps3;
    public AudioClip playerSteps4;


    // Start is called before the first frame update
    void Start()
    {
        // if scene is menu, play menu music
        if (SceneManager.GetActiveScene().name == "main Menu")
        {
            MusicSource.Stop();
            MusicSource.clip = menuMusic;
            MusicSource.loop = true;
            MusicSource.Play();
        }
        //else play random background music
        else
        {
            backgroundMusic = new AudioClip[] {backgroundMusic1, backgroundMusic2, backgroundMusic3};
            PlayRandomBackgroundMusic();

            playerSteps = new AudioClip[] {playerSteps1, playerSteps2, playerSteps3, playerSteps4};
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpeedUpMusic()
    {
        MusicSource.pitch = 1.5f;
    }

    public void SlowDownMusic()
    {
        MusicSource.pitch = 1.0f;
    }

    public void PlayButtonClick()
    {
        SFXSource.PlayOneShot(buttonClick);
    }

    public void PlayGameOver()
    {
        SFXSource.PlayOneShot(gameOver);
    }

    public void PlayGameWin()
    {
        SFXSource.PlayOneShot(gameWin);
    }

    public void PlayPlayerJump()
    {
        SFXSource.PlayOneShot(playerJump);
    }

    public void PlayPlayerDeath()
    {
        SFXSource.volume = 0.02f;
        SFXSource.PlayOneShot(playerDeath);
    }

    public void PlayPlayerHurt()
    {
        SFXSource.volume = 0.2f;
        SFXSource.PlayOneShot(playerHurt);
    }

    public void PlayPlayerAttack1()
    {
        SFXSource.PlayOneShot(playerAttack1);
    }

    public void PlayPlayerAttack2()
    {
        SFXSource.PlayOneShot(playerAttack2);
    }

    public void PlayPlayerCollect()
    {
        SFXSource.PlayOneShot(playerCollect);
    }

    public void PlayEnemyAttack()
    {
        SFXSource.PlayOneShot(enemyAttack);
    }

    public void PlayEnemyDeath()
    {
        SFXSource.volume = 0.05f;
        SFXSource.PlayOneShot(enemyDeath);
    }

    public void PlayExplosion()
    {
        SFXSource.PlayOneShot(explosion);
    }

    public void PlayRandomBackgroundMusic()
    {
        int randomIndex = Random.Range(0, backgroundMusic.Length);
        MusicSource.Stop();
        MusicSource.clip = backgroundMusic[randomIndex];
        MusicSource.loop = true;
        MusicSource.Play();

        // Lower volume of background music
        MusicSource.volume = 0.1f;
    }

    public void PlayRandomPlayerSteps()
    {
        int randomIndex = Random.Range(0, playerSteps.Length);
        SFXSource.PlayOneShot(playerSteps[randomIndex]);

        SFXSource.volume = 0.5f;
    }
}
