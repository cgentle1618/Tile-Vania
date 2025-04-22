using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPIckupSFX;
    [SerializeField] float volume = 0.2f;
    [SerializeField] int pointsForEachCoin = 100;

    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForEachCoin);
            AudioSource.PlayClipAtPoint(coinPIckupSFX, Camera.main.transform.position, volume);
            // gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
