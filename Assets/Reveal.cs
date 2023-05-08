using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Reveal : MonoBehaviour
{
    public void OnReveal()
    {
        print("Reveal...");
        StartCoroutine(HandleReveal());
    }

    private IEnumerator HandleReveal()
    {
        string valueInWei = "123000000000000000";
        // { "contractAddress": "0x36AB65b4C34f27349B30e7F9CA28308762e0a313", "functionName": "commit", "params": ["123"], "abi": [ { "inputs": [{ "internalType": "uint256", "name": "_entropy", "type": "uint256" }], "name": "commit", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "anonymous": false, "inputs": [ { "indexed": false, "internalType": "bool", "name": "_win", "type": "bool" }, { "indexed": false, "internalType": "address", "name": "_player", "type": "address" }, { "indexed": false, "internalType": "uint256", "name": "_reward", "type": "uint256" } ], "name": "Game", "type": "event" }, { "inputs": [], "name": "reveal", "outputs": [], "stateMutability": "payable", "type": "function" }, { "stateMutability": "payable", "type": "receive" } ], "valueInWei": "0", "chain": { "chainId": "7701", "chainMetadata": { "chainName": "CANTO Testnet", "nativeCurrency": { "name": "CANTO", "symbol": "CANTO", "decimals": 18 }, "rpcUrls": ["https://canto-testnet.plexnode.wtf"] } }
        string jsonString = "{ \"contractAddress\": \"0x36AB65b4C34f27349B30e7F9CA28308762e0a313\", \"functionName\": \"reveal\", \"params\": [], \"abi\": [ { \"inputs\": [{ \"internalType\": \"uint256\", \"name\": \"_entropy\", \"type\": \"uint256\" }], \"name\": \"commit\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"anonymous\": false, \"inputs\": [ { \"indexed\": false, \"internalType\": \"bool\", \"name\": \"_win\", \"type\": \"bool\" }, { \"indexed\": false, \"internalType\": \"address\", \"name\": \"_player\", \"type\": \"address\" }, { \"indexed\": false, \"internalType\": \"uint256\", \"name\": \"_reward\", \"type\": \"uint256\" } ], \"name\": \"Game\", \"type\": \"event\" }, { \"inputs\": [], \"name\": \"reveal\", \"outputs\": [], \"stateMutability\": \"payable\", \"type\": \"function\" }, { \"stateMutability\": \"payable\", \"type\": \"receive\" } ], \"valueInWei\": \"" + valueInWei + "\", \"chain\": { \"chainId\": \"7701\", \"chainMetadata\": { \"chainName\": \"CANTO Testnet\", \"nativeCurrency\": { \"name\": \"CANTO\", \"symbol\": \"CANTO\", \"decimals\": 18 }, \"rpcUrls\": [\"https://canto-testnet.plexnode.wtf\"] } } }";
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

        UnityWebRequest request = new UnityWebRequest("localhost:9680/sendContract", "POST");
        request.uploadHandler = new UploadHandlerRaw(jsonBytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
        Debug.Log(request.error);
        string response = request.downloadHandler.text;
        Debug.Log(response);
    }
}
