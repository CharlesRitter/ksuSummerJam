using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    GameObject mainCamera;
    public GameObject spawnTransition;
    bool inTransition = false;
    public float cameraStop;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

        if (inTransition)
        {
            mainCamera.transform.Translate(new Vector3(0, 0, 30) * Time.deltaTime, Space.World);
            if (mainCamera.transform.position.z >= cameraStop)
            {
                inTransition = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            inTransition = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<PlayerDeath>().spawn = spawnTransition;
        }
        
    }
}
