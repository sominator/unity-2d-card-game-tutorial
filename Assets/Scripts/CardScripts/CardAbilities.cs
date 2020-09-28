using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class CardAbilities : NetworkBehaviour
{
    public PlayerManager PlayerManager;

    void Start()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
    }

    public abstract void OnCompile();

    public abstract void OnExecute();
}
