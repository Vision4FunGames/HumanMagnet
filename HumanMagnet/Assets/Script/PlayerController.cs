using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Mid;
    public Transform leftHand;
    public Transform leftFoot;
    public Transform rightHand;
    public Transform rightFoot;
    public Transform head;
    public Rigidbody _rb;

    public void MovePlayer()
    {
        _rb.AddForce(new Vector3(0, 0, 5f));

    }
}
