using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private int count = 0;
    [SerializeField] AudioClip clickSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Debug.Log(count);
            count++;
            AudioSource.PlayClipAtPoint(clickSound,collision.transform.position);
            Destroy(collision.gameObject);
        }
    }
}
