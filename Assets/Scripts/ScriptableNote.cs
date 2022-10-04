using UnityEngine;
using NoteName = Melanchall.DryWetMidi.MusicTheory.NoteName;

[CreateAssetMenu(fileName = "MusicNote", menuName = "ScriptableObject/MusicNote")]
public class ScriptableNote : ScriptableObject
{
    [SerializeField] private NoteName noteRestriction;
    [Range(-1, 9)][SerializeField] private int octaveNumber;
    [SerializeField] private int mIDIValue;
    [SerializeField] private Color32 color;
    [SerializeField] private int scorePoint;
    [SerializeField] private KeyCode inputKey;

    
    public NoteName GetNoteRestriction()
    {
        return noteRestriction;
    }
    
    public int GetOctaveNumber()
    {
        return octaveNumber;
    }

    public int GetmIDIValue()
    {
        return mIDIValue;
    }
    
    public Color32 GetColor()
    {
        return color;
    }
    
    public int GetScorePoint()
    {
        return scorePoint;
    }
    
    public KeyCode GetKeyCode()
    {
        return inputKey;
    }
}
