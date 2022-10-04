using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class KeyPanelNote : MonoBehaviour
{
    private SpriteRenderer _notePlayerSpriteRenderer;
    [SerializeField] private TextMeshPro inputText;
    [SerializeField] private ScriptableNote musicNote;

    private void Awake()
    {
        _notePlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        inputText = GetComponentInChildren<TextMeshPro>();
    }

    void Update()
    {
        UpdateNotePlayer();
    }

    private void UpdateNotePlayer()
    {
        if (musicNote)
        {
            _notePlayerSpriteRenderer.color = musicNote.GetColor();
            inputText.text = musicNote.GetKeyCode().ToString();
        }
    }
}
