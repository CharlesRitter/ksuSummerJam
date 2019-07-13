using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == GameObject.Find("SeasonSwitcher"))
                {
                    GameObject seasonSwitcher = hit.transform.gameObject;
                    GetComponentInParent<GetCircleWorldPosition>().seasonSwitcher = hit.transform.gameObject;
                    seasonSwitcher.GetComponent<Collider>().enabled = false;
                    foreach (Transform child in hit.transform)
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
