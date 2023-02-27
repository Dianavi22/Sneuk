﻿using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public AudioClip killSound;
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            Debug.Log("Touché");
            Destroy(objectToDestroy);
        }
    }
}
