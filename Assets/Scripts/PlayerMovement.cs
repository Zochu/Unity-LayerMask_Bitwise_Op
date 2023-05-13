using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 currentPosition;

    private void Start()
    {
        currentPosition = this.transform.position;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            currentPosition = Vector3.Lerp(currentPosition, currentPosition + (Input.GetAxisRaw("Horizontal") > 0 ? Vector3.right : Vector3.left), speed * Time.deltaTime);
            this.transform.position = currentPosition;
        }
    }
}
