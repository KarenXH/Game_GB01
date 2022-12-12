using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeToDestroy=4f;
    public void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }


}
