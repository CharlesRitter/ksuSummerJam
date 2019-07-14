using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Lean.Pool;

public class AIBehavior : MonoBehaviour
{
    public GameObject target;
    public ParticleSystem partSys;
    public Transform blowRangeTransform;
    public float rotationSpeed;
    public float blowForce = 50f;
    public bool blowing;
    public float fadeInTime = .5f;
    public AudioClip snowmanMovementSound;
    public float movementSoundVolume = 1f;
    public AudioClip snowmanBlowSound;
    public float blowSoundVolume = 1f;
    public AudioClip snowmanLaughSound;


    NavMeshAgent navMeshAgent;
    AudioSource audioSource;
    GameObject player;
    bool inBlowRange;
    bool stopped;
    bool moving;
    float blowRange = 20f;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        partSys = GetComponentInChildren<ParticleSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = player;
        blowRange = Vector3.Distance(transform.position, blowRangeTransform.position);
        navMeshAgent.updateRotation = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            FaceTarget(target.transform.position);

            MoveTo(player.transform.position);

            // if(!moving && navMeshAgent.){
            //     moving = true;
            //     PlaySnowmanMovementSound();
            // }
            // if(moving){
            //     moving = false;
            //     StopSnowmanMovementSound();
            // }
        }


        if (GetPlayerDistance() < blowRange && !stopped)
        {
            if (!blowing){
                StartBlowing();
                //StopSnowmanMovementSound();
            }
        }
        else
        {
            if (blowing) {
                StopBlowing();
                //PlaySnowmanMovementSound();
            }
        }
    }

    void MoveTo(Vector3 target)
    {
        navMeshAgent.destination = target;
    }

    public void StartBlowing()
    {
        blowing = true;
        partSys.Play();

        Debug.Log("play blow");
        //PlaySnowmanBlowSound();
    }

    void StopBlowing()
    {
        blowing = false;
        partSys.Stop();
        //StopSnowmanBlowSound();
    }

    void FaceTarget(Vector3 destination)
    {
        Vector3 lookpos = destination - transform.position;
        lookpos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookpos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
    }

    float GetPlayerDistance()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }

    public void StopSnowman()
    {
        navMeshAgent.updatePosition = false;
        stopped = true;
    }

    public void StartSnowman()
    {
        navMeshAgent.updatePosition = true;
        stopped = false;
    }
    void PlaySnowmanMovementSound()
    {
        audioSource.clip = snowmanMovementSound;
        StartCoroutine(FadeIn(audioSource, fadeInTime, movementSoundVolume));
    }

    void StopSnowmanMovementSound()
    {
        audioSource.clip = snowmanMovementSound;
        StartCoroutine(FadeOut(audioSource, fadeInTime, movementSoundVolume));
    }


    void PlaySnowmanBlowSound()
    {
        audioSource.clip = snowmanBlowSound;
        StartCoroutine(FadeIn(audioSource, fadeInTime, blowSoundVolume));
    }

    void StopSnowmanBlowSound()
    {
        audioSource.clip = snowmanBlowSound;
        StartCoroutine(FadeOut(audioSource, fadeInTime, blowSoundVolume));
    }



    IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float fadeToVolume)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < fadeToVolume)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
    IEnumerator FadeOut(AudioSource audioSource, float FadeTime, float fadeFromVolume)
    {
        audioSource.Play();
        audioSource.volume = fadeFromVolume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}
