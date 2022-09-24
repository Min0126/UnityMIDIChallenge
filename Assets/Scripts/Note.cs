using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Vector3 spawnPos;

    [SerializeField]
    private int despawnOffset = 20;

    private float timeSpawned;

    float timeElapsed;

    // public float assignedTime; // time that player suppose to tap the note
    // // Start is called before the first frame update
    void Start()
    {
        timeSpawned = SongManager.Instance.audioTime;
        timeElapsed = 0;
        spawnPos = transform.position;
    }

    // // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*SongManager.Instance.noteSpeed*Time.deltaTime);
        //////////////////////////////////////////////////////
        // double timeSinceSpawned =
        //     SongManager.GetAudioSourceTime() - timeSpawned;
        // float timeRatio =
        //     ((float) timeSinceSpawned / (SongManager.Instance.noteTime * 2));
        // double timeSinceSpawned = SongManager.Instance.audioTime - timeSpawned;
        // float timeRatio =
        //     ((float) timeSinceSpawned / (SongManager.Instance.noteTime));
        //////////////////////////////////////////////////////////////////
        // timeElapsed = SongManager.Instance.audioTime - timeSpawned;
        // float timeRatio = timeElapsed / SongManager.Instance.noteTime;

        // Vector3 despawnPos =
        //     new Vector3(spawnPos.x, spawnPos.y - despawnOffset, spawnPos.z);

        // if (timeElapsed < SongManager.Instance.noteTime)
        // {
        //     transform.position +=
        //         Vector3
        //             .Lerp(Vector3.down * spawnPos.y,
        //             Vector3.down * despawnPos.y,
        //             timeRatio);
         

            // Debug.Log($"timeElapsed: {timeElapsed} name:{gameObject.name}");
            // timeElapsed += Time.deltaTime * SongManager.Instance.noteSpeed;
        // }
        // else
        // {
        //     Destroy (gameObject);
        // }

        // transform.position = Vector3.Lerp(spawnPos, despawnPos, timeRatio);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DespawnLine"))
        {
            Destroy (gameObject);
        }
    }
}
