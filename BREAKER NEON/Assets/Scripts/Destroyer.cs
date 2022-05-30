using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float time;
    void Start()
    {
        Destroy(this.gameObject,time);
    }
}
