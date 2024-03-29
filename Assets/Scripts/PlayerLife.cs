using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public PlayerMovement movement;

    private SpriteRenderer sprite;

    public float restartDelay = 1f;

    public AudioSource dieSound;

    private BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        movement = GetComponent<PlayerMovement>();
        dieSound = GetComponent<AudioSource>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Barrier")
        {
            Die();
        }
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        sprite.enabled = false;
        movement.enabled = false;
        coll.enabled = false;
        dieSound.Play();
        Invoke(nameof(Restart), restartDelay);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
