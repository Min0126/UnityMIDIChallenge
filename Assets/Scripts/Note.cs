using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private double timeSpawned;

    public float assignedTime; // time that player suppose to tap the note

    // Start is called before the first frame update
    void Start()
    {
        timeSpawned = SongManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceSpawned =
            SongManager.GetAudioSourceTime() - timeSpawned;
        float timeRatio =
            ((float) timeSinceSpawned / (SongManager.Instance.noteTime * 2));

        if (timeRatio > 1)
        {
            Destroy (gameObject);
        }
        else
        {
            transform.position =
                Vector3
                    .Lerp(Vector3.up * SongManager.Instance.noteSpawnY,
                    Vector3.up * SongManager.Instance.noteDespawnY,
                    timeRatio);
        }
    }
}
