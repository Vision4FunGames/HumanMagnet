using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AmmoScript : MonoBehaviour
{
    //public GameObject ammoStarter;
    public Rigidbody[] rbs;
    public float destrucStrengthMultiplier;

    private void Start()
    {
        DestrucFirst();
    }

    public void DestrucFirst()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigid in rbs)
        {
            rigid.isKinematic = false;
            rigid.useGravity = true;
            rigid.AddForce(new Vector3(
                rigid.transform.localPosition.x +
                Random.Range(destrucStrengthMultiplier, destrucStrengthMultiplier * 3) * 3,
                Random.Range(destrucStrengthMultiplier, destrucStrengthMultiplier * 3),
                rigid.transform.position.z+5000f));
            //Destroy(rigid.gameObject, 0.5f);
        }
    }
}