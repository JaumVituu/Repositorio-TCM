using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    private GameObject TiroPrefab;
    private bool tiro;
    void Start()
    {
        tiro = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            tiro = true;
        }
        if (tiro)
        {
            TiroPrefab = Resources.Load<GameObject>("Tiro");
            TiroPrefab.tag = "Cavalo";
            Instantiate(TiroPrefab, Vector3.zero, Quaternion.identity);
            tiro = false;
        }

    }
}
