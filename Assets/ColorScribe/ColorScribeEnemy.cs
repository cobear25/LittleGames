using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScribeEnemy : MonoBehaviour
{
    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;
    public Material yellowMaterial;
    public Material whiteMaterial;
    public Material blackMaterial;

    public GameObject bulletPrefab;

    public ColorScribeGameController gameController;

    Material currentMaterial;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        int randomMaterial = Random.Range(0, 6);
        if (randomMaterial == 0) currentMaterial = redMaterial;
        if (randomMaterial == 1) currentMaterial = greenMaterial;
        if (randomMaterial == 2) currentMaterial = blueMaterial;
        if (randomMaterial == 3) currentMaterial = yellowMaterial;
        if (randomMaterial == 4) currentMaterial = whiteMaterial;
        if (randomMaterial == 5) currentMaterial = blackMaterial;
        GetComponent<MeshRenderer>().material = currentMaterial;
        speed = Random.Range(10.0f, 14.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
    }

    public void ColorTyped(string colorString) {
        // if (Vector3.Distance(transform.position, Vector3.zero) > 25) return;
        
        if ((colorString.ToLower() == "red" || colorString.ToLower() == "rojo") && currentMaterial == redMaterial) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(0, 3.0f, 0);
            bullet.GetComponent<ColorScribeBullet>().enemyToHit = this.gameObject;
            bullet.GetComponent<MeshRenderer>().material = currentMaterial;
        }
        if ((colorString.ToLower() == "blue" || colorString.ToLower() == "azul") && currentMaterial == blueMaterial) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(0, 3.0f, 0);
            bullet.GetComponent<ColorScribeBullet>().enemyToHit = this.gameObject;
            bullet.GetComponent<MeshRenderer>().material = currentMaterial;
        }
        if ((colorString.ToLower() == "green" || colorString.ToLower() == "verde") && currentMaterial == greenMaterial) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(0, 3.0f, 0);
            bullet.GetComponent<ColorScribeBullet>().enemyToHit = this.gameObject;
            bullet.GetComponent<MeshRenderer>().material = currentMaterial;
        }
        if ((colorString.ToLower() == "yellow" || colorString.ToLower() == "amarillo") && currentMaterial == yellowMaterial) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(0, 3.0f, 0);
            bullet.GetComponent<ColorScribeBullet>().enemyToHit = this.gameObject;
            bullet.GetComponent<MeshRenderer>().material = currentMaterial;
        }
        if ((colorString.ToLower() == "black" || colorString.ToLower() == "negro") && currentMaterial == blackMaterial) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(0, 3.0f, 0);
            bullet.GetComponent<ColorScribeBullet>().enemyToHit = this.gameObject;
            bullet.GetComponent<MeshRenderer>().material = currentMaterial;
        }
        if ((colorString.ToLower() == "white" || colorString.ToLower() == "blanco") && currentMaterial == whiteMaterial) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = new Vector3(0, 3.0f, 0);
            bullet.GetComponent<ColorScribeBullet>().enemyToHit = this.gameObject;
            bullet.GetComponent<MeshRenderer>().material = currentMaterial;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet") {
            gameController.EnemyDestroyed();
        }
        if (other.tag == "Player") {
            gameController.GameOver();
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
