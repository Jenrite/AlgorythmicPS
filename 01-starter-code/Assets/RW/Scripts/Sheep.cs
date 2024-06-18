using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sheep: MonoBehaviour
{
    public float runSpeed;
    public float dropDestroyDelay;
    private bool dropped;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    public GameObject FeedbackHeart;
    public class SheepEvent : UnityEvent<Sheep> { }
    public SheepEvent OnAteHay = new SheepEvent();
    public SheepEvent OnDropped = new SheepEvent();

    private void Awake()
    {
        myCollider = GetComponent<BoxCollider>();
        myRigidbody = GetComponent<Rigidbody>();
    }
    public void EatHay()
    {
        OnAteHay?.Invoke(this);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        Destroy(gameObject);
        SFXManager.Instance.PlaySheepHitSFX();
        Instantiate(FeedbackHeart, transform.position, Quaternion.identity);
    }

    private void Drop()
    {
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
        OnDropped?.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay"))
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
            SFXManager.Instance.PlaySheepDropSFX();
        }

    }

}
