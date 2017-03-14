using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public float espera;
    public GameObject obstaculo;
    public float tempoDestruicao;
    
    public static GameController instancia = null;

	void Awake () {
        if(instancia == null){
            instancia = this;
        }
        else if (instancia != null){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
	}

    void Start(){
        StartCoroutine(GerarObstaculos());

    }

    IEnumerator GerarObstaculos(){
        while (true){
            Vector3 pos = new Vector3(15f, Random.Range(0.6f, 4.5f), 0f);
            GameObject obj = Instantiate(obstaculo, pos, Quaternion.identity) as GameObject;
            Destroy(obj, tempoDestruicao);
            yield return new WaitForSeconds(espera);
        }
    }

	void Update () {
	
	}
}
