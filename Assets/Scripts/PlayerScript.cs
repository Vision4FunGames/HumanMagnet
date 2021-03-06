using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

//karakter şekil belirleyici
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
    public bool ammoBool = false;
    public float timer;

    private void Start()
    {
        Animator();
    }

//stateleregöre ne olacağı belirlenen yer
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
        else if (!rightLegB&&!leftLegB)
        {
            playerState = PlayerState.None;
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
        //başlangıç ve karakter move
        if (GameManager.Instance.isPlay)
        {
            timer += Time.fixedDeltaTime;
            if (timer > 3f)
            {
                ammoBool = true;
            }

            var pos = transform.position;
            pos.x = Mathf.Clamp(transform.position.x, -0.4f, 0.4f);
            transform.position = pos;

            Vector3 direction = Vector3.forward * _DynamicJoystick.Vertical +
                                Vector3.right * _DynamicJoystick.Horizontal;

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


    public void OnTriggerEnter(Collider other)
    {
        //karakter bonus ayarları ve coin ayarları bu trigger içerisinde 
        if (other.CompareTag("Bonus"))
        {
            if (!headB && !leftHandB && !rightHandB && !leftLegB && !rightLegB && !hipB && !bodyB)
            {
                if (ammoBool)
                {
                    Debug.Log("AMMO GELDİİİ VAR");
                    StartCoroutine(timers());
                    ammoBool = false;
                    timer = 0;
                }
            }
            else if (headB || leftHandB || rightHandB || leftLegB || rightLegB || hipB || bodyB)
            {
                playerState = PlayerState.None;
                GameManager.Instance.SwichCase();
            }
        }

        if (other.CompareTag("Coin"))
        {
            // GameManager.Instance.DolarSc.GetComponent<DolarsScripts>().SpawnDolars();
            GameManager.Instance.coinObj.GetComponent<CoinScript>()
                .StartCoroutine((GameManager.Instance.coinObj.GetComponent<CoinScript>().CoinPlus()));

            Debug.Log("asd");
        }

        if (other.CompareTag("Finish"))
        {
            GameManager.Instance.levelWinP.SetActive(true);
        }
    }

    public void AttackBonus()
    {
    }

    public IEnumerator timers()
    {
        //  StartCoroutine(AmmoStart());

        Vector3 ammoPos = new Vector3(GameManager.Instance.characterGun.transform.position.x,
            GameManager.Instance.characterGun.transform.position.y,
            GameManager.Instance.characterGun.transform.position.z + .3f);
        Instantiate(GameManager.Instance.RandomAmmo, ammoPos, Quaternion.identity);
        GameManager.Instance.characterGun.SetActive(true);
        playerState = PlayerState.characterGun;
        yield return new WaitForSeconds(3f);
        Instantiate(GameManager.Instance.RandomAmmo, ammoPos, Quaternion.identity);
        GameManager.Instance.characterGun.SetActive(false);
        playerState = PlayerState.None;
        GameManager.Instance.SwichCase();
    }


    /*  public IEnumerator AmmoStart()
      {
          yield return new WaitForSeconds(10f);

      }*/
}