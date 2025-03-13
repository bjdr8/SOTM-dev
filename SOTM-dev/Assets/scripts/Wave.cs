using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<EnemyCard> wave = new List<EnemyCard>();

    public int waveIndex;

    void Start()
    {
        // Optionally, you can assign the index at runtime if needed
        waveIndex = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
