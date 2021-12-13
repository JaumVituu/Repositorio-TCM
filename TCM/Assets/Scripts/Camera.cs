using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private float Lenght;
    private float Posicaoinicial;

    public Transform cam;

    public float ParallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        Posicaoinicial = transform.position.x;
        Lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float Distancia = cam.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(Posicaoinicial + Distancia, transform.position.y, transform.position.z);
    }
}
