using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private GameObject[] lights;
    [SerializeField] private TMP_Text countdown;
    [SerializeField] private TMP_Text go;

    [SerializeField] private GameObject[] ui;

    [SerializeField] AudioSource lightOn;
    [SerializeField] AudioSource countdownSound;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGame()
    {
        lights[0].SetActive(true);
        lightOn.Play();

        yield return new WaitForSeconds(1f);

        lights[1].SetActive(true);
        lightOn.Play();

        yield return new WaitForSeconds(1f);

        countdown.gameObject.SetActive(true);
        countdownSound.Play();  

        yield return new WaitForSeconds(1f);

        countdown.text = "2";
        countdownSound.Play();

        yield return new WaitForSeconds(1f);

        countdown.text = "1";
        countdownSound.Play();

        yield return new WaitForSeconds(1f);

        countdown.gameObject.SetActive(false);
        go.gameObject.SetActive(true);

        countdownSound.Play();
        yield return new WaitForSeconds(0.1f);
        countdownSound.Play();
        yield return new WaitForSeconds(0.1f);
        countdownSound.Play();
        yield return new WaitForSeconds(0.3f);


        go.gameObject.SetActive(false);

        foreach(GameObject gameObject in ui)
        {
            gameObject.SetActive(true);
        }

        lights[0].SetActive(false);
        lights[1].SetActive(false);
        lights[2].SetActive(true);

        movement.Movement1();
    }
}
