using UnityEngine;
using System.Collections;

public class ECdestroyMe : MonoBehaviour{

    float timer;
    public float deathtimer = 10;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= deathtimer)
        {
            Destroy(gameObject);
        }
	
	}
}
