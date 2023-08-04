using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button0 : MonoBehaviour
{
    public float waitBeforeScene1 = 3.0f;
    public FadeIn fadeInScript;

    public AudioClip Scene0Audio;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Scene0Audio;
        audioSource.Play();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component attached to the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonActivate()
    {
            fadeInScript.StartFadeIn(); // Fades the black UI element so the initial scene becomes visible
            StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(waitBeforeScene1); // Wait before loading the next scene
        SceneManager.LoadScene("GameScene1"); // Auto load next scene
        audioSource.Stop(); // Stops all audio from playing
    }
}