using System;
using System.Collections;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}