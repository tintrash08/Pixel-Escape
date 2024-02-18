using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    bool isGameStarted = false;
    public UIManager uiManager;

    public GameObject tapToStartText;
    public TextMeshProUGUI scoreText;

    public UIManager UIManager;
    public AudioSource soundEffectsAudioSource;
    public AudioClip blockHitSoundEffect;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            uiManager.modifyActiveStatusOfElements(tapToStartText, false);
            StartSpawning();
            isGameStarted = true;
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, 1f);
    }

    void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(blockPrefab, spawnPos, Quaternion.identity);
    }

    public void GameOver()
    {
        soundEffectsAudioSource.PlayOneShot(blockHitSoundEffect, 0.5f);
        UIManager.GameOver();
        Time.timeScale = 0f;
    }

}
