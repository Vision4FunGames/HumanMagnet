using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GAME CHARACTER
    public bool isPlay = true;
    public Animator _anim;
    public PlayerScript PlayerScript;
    public Obstacle obstacle;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject head;
    public GameObject body;
    public GameObject hip;
    
    //GAME FireınTheHole
    public GameObject characterGun;
    public GameObject ammoGo;
    public AmmoScript ammoScript;
    public GameObject RandomAmmo;

    //GAME UI
    public GameObject diedPanel;
    public GameObject settingsPanel;
    public GameObject mainMenuP;
    public GameObject levelCompSpline;
    public GameObject DolarSc;
    public GameObject coinObj;

    //GAMELevelPlayerPrebs


    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager is Null");

            return _instance;
        }
    }

    public void SwichCase()
    {
        switch (PlayerScript.playerState)
        { 
            
            //switch case mantığı şöyle çalışıyor istediğimiz case i çağırıp atıyorum none onun içerisindeki break a kadar olan kodları çekmemize yarıyor bunuda playerstate=PlayerState.None ile çağırıp
            //Switch e sokmak içinGM.Instance.SwichCase(); yapılıp çalıştırılıyor PlayerScript ve Obstacle ın içinde çok sayıda kodlama görünmesini istemediğimiz için
            //böyle çalışılması gereken bir proje olduğunu düşünüyorum.
            case PlayerState.None:
                Debug.Log("None");
                _anim.CrossFade("metarig|running", 0.5f);
                PlayerScript.rightLegB = false;
                PlayerScript.leftLegB = false;
                PlayerScript.leftHandB = false;
                PlayerScript.rightHandB = false;
                PlayerScript.bodyB = false;
                PlayerScript.hipB = false;
                rightLeg.SetActive(true);
                leftLeg.SetActive(true);
                body.SetActive(true);
                hip.SetActive(true);
                break;
            case PlayerState.leftHand:
                Debug.Log("solkol");
                break;
            case PlayerState.leftLeg:
                _anim.CrossFade("metarig|cripp run_L_R", 0.5f);
                break;
            case PlayerState.rightHand:
                Debug.Log("sagkol");
                break;
            case PlayerState.rightLeg:
                Debug.Log("sagbacak");
                _anim.CrossFade("metarig|cripp run_L_R", 0.5f);
                break;
            case PlayerState.bodys:
                _anim.CrossFade("metarig|cripp run_L_R", 0.5f);
                leftHand.SetActive(false);
                rightHand.SetActive(false);
                head.SetActive(false);
                //UI ile birlikte yapılacak 
                Debug.Log("ortakısım");
                break;
            case PlayerState.twoLeg:
                Debug.Log("ikibacak");
                _anim.CrossFade("metarig|crawling", 0.5f);
                break;
            case PlayerState.heads:
                Debug.Log("kafa");
                break;
            case PlayerState.downMid:
                Debug.Log("altkısım");
                break;
            case PlayerState.legAndHand:
                Debug.Log("elayak");
                _anim.CrossFade("metarig|cripp run_L_R", 0.5f);
                break;
            case PlayerState.characterGun:
                Debug.Log("characterGun");
                characterGun.SetActive(true);
                PlayerScript.playerGun = false;
                break;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void MainManuPanel()
    {
        mainMenuP.SetActive(false);
        settingsPanel.SetActive(true);
        diedPanel.SetActive(false);
    }

    public void DiedPanel()
    {
        settingsPanel.SetActive(false);
        mainMenuP.SetActive(true);
        diedPanel.SetActive(false);
    }

    public void SettingPanel()
    {
        settingsPanel.SetActive(false);
        mainMenuP.SetActive(false);
        diedPanel.SetActive(false);
    }
}