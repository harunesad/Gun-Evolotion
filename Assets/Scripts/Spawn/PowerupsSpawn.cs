using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsSpawn : MonoBehaviour
{
    public List<GameObject> powerup;
    public List<GameObject> powerdown;
    Vector3 pos;
    public List<float> posX;
    public List<float> posZ;
    void Start()
    {
        RandomPower();
        RandomPower();
        RandomPower();
    }
    void RandomPower()
    {
        int random = Random.Range(0, powerup.Count);
        int randomPosX = Random.Range(0, posX.Count);
        int randomPosZ = Random.Range(0, posZ.Count);

        Instantiate(powerup[random], new Vector3(posX[randomPosX], 2, posZ[randomPosZ]), Quaternion.identity);
        float pos = posX[randomPosX];
        posX.RemoveAt(randomPosX);
        Instantiate(powerdown[random], new Vector3(posX[0], 2, posZ[randomPosZ]), Quaternion.identity);

        powerup.RemoveAt(random);
        powerdown.RemoveAt(random);
        posZ.RemoveAt(randomPosZ);
        posX.Add(pos);
    }
}
