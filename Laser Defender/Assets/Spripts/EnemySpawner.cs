using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // We have changed the return type of the Start() method to IEnumerator
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIdex = startingWave; waveIdex < waveConfigs.Count; waveIdex++)
        {
            var currentWave = waveConfigs[waveIdex];
            // Waiting until the wave is done spawning enemies and then move to the next wave
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {

        /* We spawn N amount of enemies (number of enemies is stored at waveconfig)
         * Next, we assing WaveConfig to each of the spawned enemies, so that the enemy
         * has access to the waypoints and movement speed.
         * Then we wait X amount of seconds before spawning the next enemy.
         * Repeat all the steps again for X amout of enemies (stored at waveconfig)
         */

        // Spawning miltiple enemies
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
