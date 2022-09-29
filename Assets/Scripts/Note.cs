using UnityEngine;

public class Note : MonoBehaviour
{
    private double timeInstantiated;
    private SpriteRenderer noteSprite;
    public float assignedTime;

    private void Awake()
    {
        noteSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        MoveNote();
    }

    private void MoveNote()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.SongManagerInstance.GetNoteTime() * 2));


        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.SongManagerInstance.GetNoteSpawnY(),
                Vector3.up * SongManager.SongManagerInstance.GetNoteDespawnY(), t);
            if (!noteSprite.enabled)
            {
                noteSprite.enabled = true;
            }
        }
    }

    public void AssignedValue(Color32 noteColor, float time)
    {
        noteSprite.color = noteColor;
        assignedTime = time;
    }
}
