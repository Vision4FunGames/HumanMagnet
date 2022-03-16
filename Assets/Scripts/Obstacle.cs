using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obstacle : MonoBehaviour
{
    public Rigidbody[] rbs;
    public float destrucStrengthMultiplier;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftLeg"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.PlayerScript.leftLegB = true;
            var transPos = other.transform.position;
            Instantiate(GameManager.Instance.PlayerScript.leftLeg, new Vector3(transPos.x, transPos.y, transPos.z),
                Quaternion.identity);
            GameManager.Instance.PlayerScript.Test1();
        }

        if (other.CompareTag("RightLeg"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.PlayerScript.rightLegB = true;
            var transPos = other.transform.position;
            Instantiate(GameManager.Instance.PlayerScript.rightLeg, new Vector3(transPos.x, transPos.y, transPos.z),
                Quaternion.identity);
            GameManager.Instance.PlayerScript.Test1();
        }

        if (other.CompareTag("Body"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.PlayerScript.bodyB = true;
            var transPos = other.transform.position;
            Instantiate(GameManager.Instance.PlayerScript.body, new Vector3(transPos.x, transPos.y, transPos.z),
                Quaternion.identity);
            GameManager.Instance.PlayerScript.Test1();
        }

        if (other.CompareTag("LeftHand"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.PlayerScript.leftHandB = true;
            var transPos = other.transform.position;
            Instantiate(GameManager.Instance.PlayerScript.leftHand, new Vector3(transPos.x, transPos.y, transPos.z),
                Quaternion.identity);
            GameManager.Instance.PlayerScript.Test1();
        }

        if (other.CompareTag("RightHand"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.PlayerScript.rightHandB = true;
            var transPos = other.transform.position;
            Instantiate(GameManager.Instance.PlayerScript.rightHand, new Vector3(transPos.x, transPos.y, transPos.z),
                Quaternion.identity);
            GameManager.Instance.PlayerScript.Test1();
        }

        if (other.CompareTag("Hip"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.PlayerScript.hipB = true;
            var transPos = other.transform.position;
            Instantiate(GameManager.Instance.PlayerScript.hip, new Vector3(transPos.x, transPos.y, transPos.z),
                Quaternion.identity);
            GameManager.Instance.PlayerScript.Test1();
        }

        if (other.CompareTag("Head"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.PlayerScript.headB = true;
            var transPos = other.transform.position;
            Instantiate(GameManager.Instance.PlayerScript.head, new Vector3(transPos.x, transPos.y, transPos.z),
                Quaternion.identity);
            GameManager.Instance.PlayerScript.Test1();
        }

        if (other.CompareTag("Ammo"))
        {
            DestrucFirst();
        }
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