using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespownPlayer : MonoBehaviour
{
    //bool firstStart = true;
    static float[] respawnPlayerPos = new float[3];
    public static bool firstStart = true;
    float[] x = new float[3] { 4f, 2.5f, 0 };

    [SerializeField] GameObject player;

    void Awake()
    {
        if (firstStart)
        {
            respawnPlayerPos = (float[])x.Clone();
            firstStart = !firstStart;
        }

        Instantiate(player, new Vector3(respawnPlayerPos[0], respawnPlayerPos[1], respawnPlayerPos[2]), Quaternion.identity);
    }

    public void SetRespownPoint()
    {
        PlayerMain playerMain = FindObjectOfType<PlayerMain>();
        Vector3 newPos = playerMain.playerPos;

        respawnPlayerPos[0] = newPos.x;
        respawnPlayerPos[1] = newPos.y;
        respawnPlayerPos[2] = newPos.z;

        gameObject.transform.position = newPos;
    }

    public void Respown()
    {
        SceneManager.LoadScene(3);
    }
}
