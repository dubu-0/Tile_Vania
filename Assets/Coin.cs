using System;
using System.Collections;
using System.Collections.Generic;
using Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private int cost = 1;
    [SerializeField] private AudioClip pickupSound;

    private bool _isPickedUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player.Player>() != null && !_isPickedUp)
        {
            score.Add(cost);
            _isPickedUp = true;
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.gameObject.transform.position, 0.1f);
            Destroy(gameObject);
        }
    }
}
