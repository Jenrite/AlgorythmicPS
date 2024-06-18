using UnityEngine;

public class BaleMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rollSpeed = 100f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
    }
}