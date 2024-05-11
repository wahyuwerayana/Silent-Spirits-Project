using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter2 : MonoBehaviour
{
    [SerializeField] private Transform destination2;

    public Transform GetDestination()
    {
        return destination2;
    }
}
