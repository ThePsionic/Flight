using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour {
    public ParticleSystem particleSys;
    public Text text;
    public Button mainMenuButton;
    public GameObject sphereMinimapObj;

    private int score = 0;
    private bool isColliding = false;

    void Start()
    {
        mainMenuButton.gameObject.SetActive(false);
    }

    void Update()
    {
        isColliding = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Terrain")
        {
            particleSys.transform.position = gameObject.transform.position;
            var emission = particleSys.emission;
            emission.enabled = true;
            Destroy(gameObject);
            mainMenuButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;
        isColliding = true;
        if (other.gameObject.tag == "Collect")
        {
            score += 5;
            text.text = "Score: " + score;
            other.gameObject.transform.position = new Vector3(Random.Range(-130,350), Random.Range(0, 250), Random.Range(-130,350));
            sphereMinimapObj.transform.position = other.gameObject.transform.position;
        }
    }
}
