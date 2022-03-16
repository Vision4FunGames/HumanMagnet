using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public enum PlayerState
{
    None = 0,
    rightLeg = 1,
    leftLeg = 2,
    rightHand = 3,
    leftHand = 4,
    twoLeg = 5,
    bodys = 6,
    heads = 7,
    downMid = 8,
    legAndHand = 9,
    characterGun = 10
}

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public DynamicJoystick _DynamicJoystick;
    public Rigidbody rb;
    public float destrucStrengthMultiplier = 3f;
    public Rigidbody[] rbs;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject head;
    public GameObject body;
    public GameObject hip;
    public bool headB = true;
    public bool leftLegB = true;
    public bool rightLegB = true;
    public bool leftHandB = true;
    public bool rightHandB = true;
    public bool bodyB = true;
    public bool hipB = true;
    public bool playerGun = true;
    public PlayerState playerState = PlayerState.None;

    private void Start()
    {
        Animator();
    }

    public void Test1()
    {
        if (rightLegB && leftLegB)
        {
            playerState = PlayerState.twoLeg;
            GameManager.Instance.SwichCase();
        }
        else if (rightLegB)
        {
            playerState = PlayerState.rightLeg;
            GameManager.Instance.SwichCase();
        }
        else if (leftLegB)
        {
            playerState = PlayerState.leftLeg;
            GameManager.Instance.SwichCase();
        }
        else if (bodyB)
        {
            playerState = PlayerState.bodys;
            GameManager.Instance.SwichCase();
        }
        else if (hipB)
        {
            playerState = PlayerState.downMid;
            GameManager.Instance.SwichCase();
        }
        else if (playerGun)
        {
            playerState = PlayerState.characterGun;
            GameManager.Instance.SwichCase();
        }
    }

    // public void test(Collider other, GameObject bodyGameObject)
    // {
    //     GameManager.Instance.PlayerScript.bodyB = false;
    //     other.gameObject.SetActive(false);
    //     for (int i = 0; i < other.transform.childCount; i++)
    //     {
    //         var aa = bodyGameObject.transform.childCount;
    //         var bb = bodyGameObject.transform;
    //         for (int j = 0; j < aa; j++)
    //         {
    //             bb.GetChild(i).gameObject.SetActive(true);
    //             DestrucFirst();
    //         }
    //     }
    // }

    public void FixedUpdate()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -0.4f, 0.4f);
        transform.position = pos;

        Vector3 direction = Vector3.forward * _DynamicJoystick.Vertical + Vector3.right * _DynamicJoystick.Horizontal;

        rb.velocity = (direction * speed) * Time.fixedDeltaTime * speed;
        if (_DynamicJoystick.Horizontal > 0)
        {
            transform.DORotate(new Vector3(0, 30, 0), 1f);
        }
        else if (_DynamicJoystick.Horizontal == 0)
        {
            transform.DORotate(new Vector3(0, 0, 0), 1f);
        }
        else
        {
            transform.DORotate(new Vector3(0, -30, 0), 1f);
        }

        PlayerMoves();
    }

    public void PlayerMoves()
    {
        transform.Translate(new Vector3(0, 0, 0.05f));
    }

    public void Animator()
    {
        // GameManager.Instance._anim.SetBool("Run", true);
        GameManager.Instance._anim.CrossFade("metarig|running", 0.5f);
    }


    // public void TouchController()
    // {
    //     if (Input.GetMouseButton(0))
    //     {
    //         delta = (Input.mousePosition - initialMousePosition) * ((float) Screen.width / Screen.height) *
    //                 inputSensitivity * Time.deltaTime;
    //
    //         initialMousePosition = Input.mousePosition;
    //     }
    //
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         delta = Vector3.zero;
    //         initialMousePosition = Input.mousePosition;
    //     }
    //
    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         initialMousePosition = Input.mousePosition;
    //         delta = Vector3.zero;
    //     }
    // }
    // public void DestrucFirst()
    // {
    //     foreach (Rigidbody rigid in rbs)
    //     {
    //         rigid.isKinematic = false;
    //         rigid.useGravity = true;
    //         rigid.AddForce(new Vector3(
    //             rigid.transform.localPosition.x +
    //             Random.Range(destrucStrengthMultiplier, destrucStrengthMultiplier * 3) * 3,
    //             Random.Range(destrucStrengthMultiplier, destrucStrengthMultiplier * 3),
    //             Random.Range(-destrucStrengthMultiplier, destrucStrengthMultiplier)));
    //         Destroy(rigid.gameObject, 2f);
    //     }
    // }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            // if (leftLegB)
            // {
            //     playerState = PlayerState.leftLeg;
            //     GameManager.Instance.SwichCase();
            // }
            //
            // if (rightLegB)
            // {
            //     playerState = PlayerState.rightLeg;
            //     GameManager.Instance.SwichCase();
            // }
            //
            // if (rightLegB && leftLegB)
            // {
            //     Debug.Log("TWOLEG");
            //     playerState = PlayerState.None;
            //     GameManager.Instance.SwichCase();
            // }
            //
            // if (bodyB)
            // {
            //     playerState = PlayerState.bodys;
            //     GameManager.Instance.SwichCase();
            // }
            //
            // if (leftHandB)
            // {
            //     playerState = PlayerState.leftHand;
            //     GameManager.Instance.SwichCase();
            // }
            //
            // if (rightHandB)
            // {
            //     playerState = PlayerState.rightHand;
            //     GameManager.Instance.SwichCase();
            // }
            //
            // if (playerState == PlayerState.None)
            // {
            //     StartCoroutine(timers());
            //     GameManager.Instance.SwichCase();
            // }
            //
            // if (playerState == PlayerState.bodys)
            // {
            //     GameManager.Instance.SwichCase();
            // }
            //
            // else if (!headB && !leftHandB && !rightHandB)
            // {
            //     GameManager.Instance.rightHand.SetActive(true);
            //     GameManager.Instance.leftHand.SetActive(true);
            //     GameManager.Instance.head.SetActive(true);
            // }
            if (! headB && !leftHandB && !rightHandB && !leftLegB && !rightLegB && !hipB && !bodyB)
            {
                StartCoroutine(timers());
            }
            else if (headB || leftHandB || rightHandB || leftLegB || rightLegB || hipB || bodyB)
            {
               
                GameManager.Instance.rightHand.SetActive(true);
                GameManager.Instance.leftHand.SetActive(true);
                GameManager.Instance.head.SetActive(true);
                GameManager.Instance.rightLeg.SetActive(true);
                GameManager.Instance.leftLeg.SetActive(true);
                GameManager.Instance.head.SetActive(true);
                GameManager.Instance.body.SetActive((true));
                playerState = PlayerState.None;
            }
        }
    }

    public void AttackBonus()
    {
    }

    public IEnumerator timers()
    {
        GameManager.Instance.characterGun.SetActive(true);
        playerState = PlayerState.characterGun;
        yield return new WaitForSeconds(3f);
        GameManager.Instance.characterGun.SetActive(false);
        playerState = PlayerState.None;
    }

    public IEnumerator AmmoStart()
    {
        Instantiate(GameManager.Instance.ammoGo, GameManager.Instance.characterGun.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        
    }
}