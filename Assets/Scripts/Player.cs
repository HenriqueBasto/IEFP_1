using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private GameObject deathPrefab;

    [SerializeField]
    private TextMeshProUGUI pointsText;

    [SerializeField]
    private TextMeshProUGUI finalPointsText;

    [SerializeField]
    private GameObject finalScreen;

    [SerializeField]
    private AudioClip deathSound;

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    private AudioSource myAudioSource;

    private int points = 0;

    private bool Dead = false;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        finalScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!Dead)
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            myRigidbody.velocity = input * movementSpeed;
            myAnimator.SetFloat("XSpeed", input.x);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Dead = true;
            myAnimator.SetTrigger("Dead");
            myAudioSource.PlayOneShot(deathSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            collision.gameObject.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-3.0f, 3.0f), 0);
            Instantiate(deathPrefab);
            Debug.Log("Bati contra um Point");
            points++;
            UpdatePointsText();
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void UpdatePointsText()
    {
        pointsText.text = "Points: " + points;
    }

    private void Death()
    {
        Debug.Log("Morri");
        int SavedScore = PlayerPrefs.GetInt("MaxScore", 0);
        if (points > SavedScore)
        {
            PlayerPrefs.SetInt("MaxScore", points);
        }
        finalScreen.SetActive(true);
        finalPointsText.text = "Fizeste " + points + " pontos";
        Destroy(gameObject);
    }
}
