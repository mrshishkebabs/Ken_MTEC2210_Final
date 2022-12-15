using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
//    public int score = 0;
    public GameObject[] itemPrefab;
    public Transform leftTran;
    public Transform rightTran;

    //public TextMeshPro scoreText;

    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        InvokeRepeating("SpawnItem", 3, 2); //how long to wait, how long it happen afterwards

    }

    void Update()
    {
//        scoreText.text = "Score: " + score.ToString();
    }


    public void SpawnItem()
    {
        float rndXValue = Random.Range(leftTran.position.x, rightTran.position.x);

        Vector2 spawnPos = new Vector2(rndXValue, leftTran.position.y);

        int index = Random.Range(0, itemPrefab.Length);
        Instantiate(itemPrefab[index], spawnPos, Quaternion.identity); //Vector3.zero means center
    }

    public void IncrementScore(int value)
    {
//        score += value;
 //       Debug.Log(value);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


}