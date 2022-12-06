using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetManager : MonoBehaviour
{
    public GameObject[] streetPrefabs;
    public float whereToSpawnZ = 0;
    public float streetLenght = 30;
    public Transform playerTransform;
    private List<GameObject> activeStreets = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 5; i++){
            if (i == 0){
                SpawnStreet(0);
            } else{
                SpawnStreet(Random.Range(0, streetPrefabs.Length));
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > whereToSpawnZ - (5 * streetLenght)){
            SpawnStreet(Random.Range(0, streetPrefabs.Length));
            DeleteStreet();
        }
    }

    public void SpawnStreet(int streetIdx){
        GameObject go = Instantiate(streetPrefabs[streetIdx], transform.forward * whereToSpawnZ, transform.rotation);
        activeStreets.Add(go);
        whereToSpawnZ += streetLenght;
    }

    private void DeleteStreet(){
        Destroy(activeStreets[0]);
        activeStreets.RemoveAt(0);
    }
}
