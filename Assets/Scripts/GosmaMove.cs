using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GosmaMove : MonoBehaviour{

    public float velocidadeHorizontal;
    public float velocidadeVertical;
    public float min;
    public float max;
    public float espera;

    void Start(){
        StartCoroutine(Move(max));
    }

    IEnumerator Move(float destino){
        while (Mathf.Abs(destino - transform.localPosition.y) > 0.1f){
            Vector3 direcao = (destino == max) ? new Vector3 (0, 1, 0) : Vector3.down;
            Vector3 velocidadeVetorial = direcao * velocidadeHorizontal;
            transform.position = transform.position + velocidadeVetorial * Time.deltaTime;

            Vector3 velocidadeVetorial1 = Vector3.left * velocidadeVertical;
            transform.position = transform.position + velocidadeVetorial1 * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(espera);

        destino = (destino == max) ? min : max;
        StartCoroutine(Move(destino));
    }
}