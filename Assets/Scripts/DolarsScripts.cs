using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class DolarsScripts : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform animationTransform;
    [SerializeField] private Transform dolarSpawnTransform;
    public Dolar dolar;
    public int dolarSpawmCount;

    // Update is called once per frame
    public void SpawnDolars(PointerEventData data)
    {

        for (int i = 0; i < dolarSpawmCount; i++)
        {
            var pos = data.position + (Random.insideUnitCircle * 240);
            var spawnObj = Instantiate(dolar, pos, Quaternion.identity, dolarSpawnTransform);
            spawnObj.moveTransform = animationTransform;
            spawnObj.DolarAnimation(i * 0.2f, 0.2f, 0.5f);

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SpawnDolars(eventData);
    }


    

}
