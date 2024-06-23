using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float steerSpeed = 150;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float boostSpeed = 15f;
    [SerializeField] float slowSpeed = 7f;

    [SerializeField] float destroyDelay = 0.5f;



    // Update is called once per frame
    void Update()
    {

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float driveUpDown = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);

        transform.Translate(0,driveUpDown,0);

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "boost"){
            Debug.Log("Boost Activated!");
            Destroy(other.gameObject, destroyDelay);
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;    }
}
