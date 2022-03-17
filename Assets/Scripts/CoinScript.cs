using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    void Start()
    {
        // StartCoroutine(nameof(CoinPlus));

    }
    //yolumuzun üzerindeki coinin sağa sola gitmesi için ayalanacak yer
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.Instance.coinObj.transform.position.x+5f, GameManager.Instance.coinObj.transform.position.y+10f, GameManager.Instance.coinObj.transform.position.z), 1.5f * Time.deltaTime);

    }

    public IEnumerator CoinPlus()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            //transform.position = Vector3.Lerp(transform.position, GameManager.Instance.coinObj.transform.position, 1.5f * Time.deltaTime);

        }

    }
}
