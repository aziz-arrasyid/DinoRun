using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class SpawnSpike : MonoBehaviour
{
    //Components Global
    [SerializeField] private GameObject spikePrefab;

    //variables
    private readonly float speed = 5f;

    private void Start()
    {
        SpikeGenerate();
    }

    public void SpikeSpawn()
    {
        if (!GameManager.Instance.GetGameOver())
        {
            float numberRandom = Random.Range(0.5f, 2f);
            Invoke(nameof(SpikeGenerate), numberRandom);
        }
    }

    private void SpikeGenerate()
    {
        GameObject spikeIns = Instantiate(spikePrefab, transform.position, Quaternion.identity);
        spikeIns.GetComponent<Spike>().spawnSpike = this;
    }

    public float GetSpeed() {  return speed; }

    public void CancelSpawn() { CancelInvoke(nameof(SpikeGenerate)); }
}
