using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeartFeedback : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(transform.position.y + 3, 2);
        transform.DOScale(new Vector3(2, 2, 2), 2);
        Invoke("Disappear", 2);
    }

    void Disappear()
    {
        Destroy(gameObject);
    }
}
