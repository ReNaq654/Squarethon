using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBlock : MonoBehaviour
{
    public AudioSource audioSource;

    private bool levelCompleted = false;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !levelCompleted)
        {
            audioSource.Play();
            levelCompleted = true;
            Invoke(nameof(LoadLevel), 1.1f); //Calls LoadLevel() method after 1.1 second delay

        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
