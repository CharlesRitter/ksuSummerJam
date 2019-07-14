using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPadlock : MonoBehaviour
{
    public Rigidbody Padlock_Handle, Padlock_Base;
    public Vector3 forceToApply1, forceToApply2;
    public float waitTime1, waitTime2;

    public bool isDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed)
        {
            StartCoroutine(PadlockDamage());
        }
    }

    IEnumerator PadlockDamage()
    {
        Padlock_Base.isKinematic = false;
        Padlock_Base.useGravity = true;
        yield return new WaitForSeconds(waitTime1);

        Padlock_Handle.isKinematic = false;
        Padlock_Handle.useGravity = true;
        yield return new WaitForSeconds(waitTime2);

        Destroy(Padlock_Base.gameObject);
        Destroy(Padlock_Handle.gameObject);

        yield return null;
    }
}
