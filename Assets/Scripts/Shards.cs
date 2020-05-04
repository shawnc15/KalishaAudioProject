using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shards : MonoBehaviour
{

    public List<GameObject> shardList;
    public bool complete;
    public int numCollected;
    public List<GameObject> barriers;
    private bool playOnce;
    private GameObject bar;
    FMODUnity.StudioEventEmitter emitter;
    // Use this for initialization
    void Start()
    {
        foreach (GameObject shard in GameObject.FindGameObjectsWithTag("shard"))
        {
            shardList.Add(shard);
        }
        foreach (GameObject barrier in GameObject.FindGameObjectsWithTag("barrier"))
        {
            barriers.Add(barrier);
        }
        complete = false;
        numCollected = 0;
        playOnce = false;
        emitter = GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Collection Progress", numCollected);
    }

    // Update is called once per frame
    void Update()
    {
        if (numCollected < shardList.Count)
        {
            for (int i = 0; i < shardList.Count; i++)
            {
                if (shardList[i] != null && shardList[i].GetComponent<MinorShard>().collected)
                {
                    numCollected++;
                    emitter.SetParameter("Collection Progress", numCollected);
                    Destroy(shardList[i]);
                }
            }
        }
        else
        {
            complete = true;
            
            foreach (GameObject barrier in GameObject.FindGameObjectsWithTag("barrier"))
            {
                barrier.GetComponent<Renderer>().enabled = false;
                barrier.GetComponent<CircleCollider2D>().enabled = false;
                bar = barrier;
                
            }
            if (!GetComponent<AudioSource>().isPlaying)
            {
                if (!playOnce)
                {
                    GetComponent<AudioSource>().clip = GetComponent<Move>().portal;
                    bar.GetComponent<FMODUnity.StudioEventEmitter>().Play();
                    //GetComponent<AudioSource>().Play();
                    playOnce = true;
                }
            }
            
            
        }

    }
}
