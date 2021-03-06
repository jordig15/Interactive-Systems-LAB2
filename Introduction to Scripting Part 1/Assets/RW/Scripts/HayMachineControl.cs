using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachineControl : MonoBehaviour
{
    public float inputKeyValue;
    public float moveAmount = 0.1f;

    public GameObject hayShootObject;
    public float ThresholdShoot = 0.5f;
    float measureTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        measureTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && (Time.time - measureTime) > ThresholdShoot)
        {
            GameObject go = Instantiate(hayShootObject, transform.position, Quaternion.identity);
            go.transform.parent = transform;
            measureTime = Time.time;
        }
    }

    void Move()
    {
        inputKeyValue = Input.GetAxis("Horizontal");
        Vector3 newPos = transform.position + Vector3.right * moveAmount * inputKeyValue;
        if (newPos.x > -20 && newPos.x < 20)
        {
            transform.Translate(Vector3.right * moveAmount * inputKeyValue);
        }
    }
}
