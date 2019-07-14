using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCircleWorldPosition : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject seasonSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seasonSwitcher)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                seasonSwitcher.transform.position = hit.point;
                Shader.SetGlobalVector("_BubblePos", seasonSwitcher.transform.position);
            }
        }
    }
}
