using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{
    public Canvas startScreen;

    private Camera mainCamera;

    void Start()
    {
        startScreen.gameObject.SetActive(true);
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }
    
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
                    startScreen.gameObject.SetActive(false);
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
