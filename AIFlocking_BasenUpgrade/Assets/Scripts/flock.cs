using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flock : MonoBehaviour {
    public float speed = 0.001f;
    float rotationSpeed = 2.0f;
    Vector2 averageHeading;
    Vector2 averagePosition;

    float neighbourDistance = 2.0f;

    bool turning = false;

	// Use this for initialization
	void Start () {
        speed = Random.Range(0.000001f, 0.005f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector2.Distance(transform.position, Vector2.zero) >= globalFlock.tankSize)
        {
            turning = true;
        }
        else turning = false;

        if(turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            this.GetComponent<Rigidbody2D>().AddForce(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  rotationSpeed * Time.deltaTime);
        }
        transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed);

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }
}
