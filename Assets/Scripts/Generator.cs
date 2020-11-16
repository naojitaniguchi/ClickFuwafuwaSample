using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] FuwaChans;
    public float waitTime = 1.0f;
    public bool generating = true;
    public float xMin = -10.0f;
    public float xMax = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("generateFuwa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator generateFuwa()
    {
        while( generating)
        {
            yield return new WaitForSeconds(waitTime);

            Vector3 pos = new Vector3(Random.Range(xMin, xMax), gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(FuwaChans[Random.Range(0, FuwaChans.Length)], pos, Quaternion.identity);
        }
    }
}
