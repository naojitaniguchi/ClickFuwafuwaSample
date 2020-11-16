using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuwaChan : MonoBehaviour
{
    public float forceMin = 100.0f;
    public float forceMax = 200.0f;
    public float xMin = -1.0f;
    public float xMax = 1.0f;
    public float zMin = -1.0f;
    public float zMax = 0.0f;
    public float hartTime = 0.5f;
    public int friendClickNum = 4;
    public float zDestroy = -10.0f;

    public GameObject particle;
    public GameObject frinedHart;
    public int clickCount;

    // Start is called before the first frame update
    void Start()
    {
        particle.SetActive(false);
        frinedHart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ( gameObject.transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Ground")
        {

            Vector3 forceVec = Vector3.up + Vector3.right * Random.Range(xMin, xMax) + Vector3.forward * Random.Range(zMin, zMax);
            forceVec *= Random.Range(forceMin, forceMax);
            gameObject.GetComponent<Rigidbody>().AddForce(forceVec);
        }
    }

    public void showParticle()
    {
        clickCount++;
        if ( clickCount > friendClickNum)
        {
            frinedHart.SetActive(true);
        }
        else
        {
            StartCoroutine("activateParticle");
        }
    }

    IEnumerator activateParticle()
    {
        particle.SetActive(true);
        yield return new WaitForSeconds(hartTime);
        particle.SetActive(false);
    }
}
