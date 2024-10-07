using System;
using UnityEngine;

public class CubeHighlight : MonoBehaviour
{
    public SequenceManager sequenceManager;
    private Renderer cubeRenderer;
    public Color HighlightColor = Color.yellow;
    public Color MouseDownColor = Color.black;
    private bool isMouseOnCube = false;
    private bool lastPlayingState = false;
    [NonSerialized]
    public Color originalColor;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
    }

    private void Update()
    {
        if (lastPlayingState!=sequenceManager.IsPlayingSequence && isMouseOnCube) {
            OnMouseEnter();
        }
        lastPlayingState = sequenceManager.IsPlayingSequence;
    }

    void OnMouseEnter()
    {
        isMouseOnCube = true;
        if (!sequenceManager.IsPlayingSequence)
        {
            ChangeColor(HighlightColor);
        }
    }

    void OnMouseExit()
    {
        isMouseOnCube = false;
        if (!sequenceManager.IsPlayingSequence)
        {
            ChangeColor(originalColor);
        }

    }

    private void OnMouseDown()
    {
        if (!sequenceManager.IsPlayingSequence)
        {
            ChangeColor(MouseDownColor);
        }

    }
    private void OnMouseUp()
    {
        if (!sequenceManager.IsPlayingSequence)
        {
            if (isMouseOnCube)
            {
                ChangeColor(HighlightColor);
            }
            else
            {
                ChangeColor(originalColor);
            }
        }
    }

    public void ChangeColor(Color color)
    {
        cubeRenderer.material.color = color;
    }
}
