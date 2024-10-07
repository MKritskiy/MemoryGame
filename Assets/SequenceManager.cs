using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    public CubeHighlight[] cubes;
    public Color HighlightColor;
    private List<int> sequence = new List<int>();
    private int currentIndex = 0;
    public bool IsPlayingSequence { get; private set; } = false;

    public void StartSequence()
    {
        IsPlayingSequence = true;
        sequence.Add(Random.Range(0, cubes.Length));
        StartCoroutine(ShowSequence());
    }

    private IEnumerator ShowSequence()
    {
        foreach (int index in sequence)
        {
            cubes[index].ChangeColor(HighlightColor);
            yield return new WaitForSeconds(1f);
            cubes[index].ChangeColor(cubes[index].originalColor);
            yield return new WaitForSeconds(0.5f);
        }
        IsPlayingSequence = false;
    }

    public bool CheckInput(int index)
    {
        if (currentIndex < sequence.Count && index == sequence[currentIndex])
        {
            currentIndex++;
            if (currentIndex == sequence.Count)
            {
                currentIndex = 0;
                DropCubeColors();
                StartSequence();
                return true;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DropCubeColors()
    {
        foreach(var cube in cubes)
        {
            cube.ChangeColor(cube.originalColor);
        }
    }
}
