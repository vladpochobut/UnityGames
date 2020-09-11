using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    float coliderHalfHV;
    void Start()
    {
        SpawnAsteroids();

    }
    public void SpawnAsteroids() 
    {
        GameObject prefabAsteroidRight = Instantiate(prefabAsteroid) as GameObject;
        CircleCollider2D collider = prefabAsteroid.GetComponent<CircleCollider2D>();
        float radius = collider.radius;
        coliderHalfHV = collider.radius / 2;
        float angleRight = Random.Range(165 * Mathf.Deg2Rad, 195 * Mathf.Deg2Rad);
        Vector3 locationRight;
        locationRight.x = ScreenUtils.ScreenRight + (2 * coliderHalfHV);
        locationRight.y = 0;
        locationRight.z = -Camera.main.transform.position.z;
        prefabAsteroidRight.GetComponent<Asteroid>().Initialize(angleRight, locationRight);

        GameObject prefabAsteroidDown = Instantiate(prefabAsteroid) as GameObject;
        float angleDown = Random.Range(60 * Mathf.Deg2Rad, 120 * Mathf.Deg2Rad);
        Vector3 locationDown;
        locationDown.x = 0;
        locationDown.y = ScreenUtils.ScreenBottom - (2*coliderHalfHV);
        locationDown.z = -Camera.main.transform.position.z;
        prefabAsteroidDown.GetComponent<Asteroid>().Initialize(angleDown, locationDown);

        GameObject prefabAsteroidLeft = Instantiate(prefabAsteroid) as GameObject;
        float angleLeft = Random.Range(30 * Mathf.Deg2Rad, -30 * Mathf.Deg2Rad);
        Vector3 locationLeft;
        locationLeft.x = ScreenUtils.ScreenLeft - (2*coliderHalfHV);
        locationLeft.y = 0;
        locationLeft.z = -Camera.main.transform.position.z;
        prefabAsteroidLeft.GetComponent<Asteroid>().Initialize(angleLeft, locationLeft);

        GameObject prefabAsteroidUp = Instantiate(prefabAsteroid) as GameObject;
        float angleUp = Random.Range(240 * Mathf.Deg2Rad, 300 * Mathf.Deg2Rad);
        
        Vector3 locationUp;
        locationUp.x = 0;
        locationUp.y = ScreenUtils.ScreenTop+(2*coliderHalfHV);
        locationUp.z = -Camera.main.transform.position.z;
        prefabAsteroidUp.GetComponent<Asteroid>().Initialize(angleUp, locationUp);

    }

}
