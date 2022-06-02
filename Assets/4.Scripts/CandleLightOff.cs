using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLightOff : MonoBehaviour
{
    [SerializeField] int childCnt = 0;
    public GameObject blazier;
    public ParticleSystem waterfall;
    [SerializeField] ParticleSystem[] fires;
    [SerializeField] bool isAnswer = false;
    [SerializeField] bool isPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        fires = GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        isAnswer = blazier.GetComponent<NormalButtonController>().isAnswer;
        WaterFallPlay();
    }

    void WaterFallPlay()
    {
        if (isAnswer && !isPlayed)
        {
            waterfall.Play();
            for(int i=0; i<fires.Length; i++)
            {
                fires[i].Stop();
            }
            isPlayed = true;

            gameObject.GetComponent<AudioSource>().Stop();

        }
    }
}
