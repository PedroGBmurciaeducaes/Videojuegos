using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{



    public PhotonView playerPrefab;
    public PhotonView playerPrefab2;

    public Transform spawnPoint;
    public Transform spawnPoint2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Correccion del bug aplicada");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Nos hemos conectado al Master");
        PhotonNetwork.JoinRandomOrCreateRoom(roomOptions: new RoomOptions { MaxPlayers = 4 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room.");

        int actor = PhotonNetwork.LocalPlayer.ActorNumber;

        if (actor == 1)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        }

        else if (actor == 2)
        {
            PhotonNetwork.Instantiate(playerPrefab2.name, spawnPoint2.position, spawnPoint2.rotation);
        }

    }
}