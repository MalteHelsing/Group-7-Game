using System.Collections;
using UnityEngine;

public class WaveConfig : MonoBehaviour
{
    [SerializeField] WaveConfig[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] bool isLooping = true;

    WaveConfig currentWave;

    void Start()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (isLooping)
        {
            foreach (WaveConfig wave in waveConfigs)
            {
                currentWave = wave;

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
    }
}