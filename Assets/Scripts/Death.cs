using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-3.0f, 3.0f), 0);
        myRigidbody.velocity = Random.insideUnitCircle.normalized * movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            myRigidbody.velocity = Random.insideUnitCircle.normalized * movementSpeed;
        }
    }
}
