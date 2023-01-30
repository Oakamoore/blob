using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MultiplayerLevelManager : MonoBehaviourPunCallbacks
{

    public GameObject[] prefabs;

    Vector3 randomPoint;

    public int maxKills = 3;
    public GameObject gameOverPopup;
    public Text winnerText;

    GameObject myPlayer;

    void Start()
    {
        randomPoint = new Vector3(UnityEngine.Random.Range(0, 10), 0, UnityEngine.Random.Range(0, 10));

        myPlayer = (GameObject) PhotonNetwork.Instantiate(prefabs[UnityEngine.Random.Range(0,4)].name, randomPoint, Quaternion.identity);
        myPlayer.GetComponentInChildren<AnimationController>().enabled = true;
        myPlayer.GetComponentInChildren<MultiplayerShooting>().enabled = true;
        myPlayer.transform.Find("FollowCamera").gameObject.SetActive(true);
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(targetPlayer.GetScore() == maxKills)
        {
            winnerText.text = targetPlayer.NickName;
            gameOverPopup.SetActive(true);
            StorePersonalBest();
        }
    }

    void StorePersonalBest()
    {
        int currentScore = PhotonNetwork.LocalPlayer.GetScore();
        PlayerData playerData = GameManager.instance.playerData;

        if(currentScore > playerData.bestScore)
        {
            playerData.username = PhotonNetwork.LocalPlayer.NickName;
            playerData.bestScore = currentScore;
            playerData.bestScoreDate = DateTime.UtcNow.ToString();
            playerData.totalPlayersInGame = PhotonNetwork.CurrentRoom.PlayerCount;
            playerData.roomName = PhotonNetwork.CurrentRoom.Name;

            GameManager.instance.globalLeaderboard.SubmitScore(currentScore);
            GameManager.instance.SavePlayerData();
        }

    }

    public void LeaveGame()
    {
        PhotonNetwork.LeaveRoom();
        myPlayer.GetComponentInChildren<MultiplayerShooting>().enabled = false;
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("Lobby");
    }

}
