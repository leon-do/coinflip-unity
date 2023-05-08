using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CanCommit : MonoBehaviour
{
    public void OnCanCommit()
    {
        print("Can commit...");
        StartCoroutine(HandleCanCommit());
    }

    private IEnumerator HandleCanCommit()
    {
        string address = "0x638105AA1B69406560f6428aEFACe3DB9da83c64";
        // { "contractAddress": "0x36AB65b4C34f27349B30e7F9CA28308762e0a313", "functionName": "commit", "params": ["123"], "abi": [ { "inputs": [{ "internalType": "uint256", "name": "_entropy", "type": "uint256" }], "name": "commit", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "anonymous": false, "inputs": [ { "indexed": false, "internalType": "bool", "name": "_win", "type": "bool" }, { "indexed": false, "internalType": "address", "name": "_player", "type": "address" }, { "indexed": false, "internalType": "uint256", "name": "_reward", "type": "uint256" } ], "name": "Game", "type": "event" }, { "inputs": [], "name": "reveal", "outputs": [], "stateMutability": "payable", "type": "function" }, { "stateMutability": "payable", "type": "receive" } ], "valueInWei": "0", "chain": { "chainId": "7701", "chainMetadata": { "chainName": "CANTO Testnet", "nativeCurrency": { "name": "CANTO", "symbol": "CANTO", "decimals": 18 }, "rpcUrls": ["https://canto-testnet.plexnode.wtf"] } }
        string jsonString = "{ \"contractAddress\": \"0x36AB65b4C34f27349B30e7F9CA28308762e0a313\", \"functionName\": \"commitments\", \"params\": [\"0x638105AA1B69406560f6428aEFACe3DB9da83c64\"], \"abi\": [ { \"anonymous\": false, \"inputs\": [ { \"indexed\": false, \"internalType\": \"bool\", \"name\": \"_win\", \"type\": \"bool\" }, { \"indexed\": false, \"internalType\": \"address\", \"name\": \"_player\", \"type\": \"address\" }, { \"indexed\": false, \"internalType\": \"uint256\", \"name\": \"_reward\", \"type\": \"uint256\" } ], \"name\": \"Game\", \"type\": \"event\" }, { \"inputs\": [{ \"internalType\": \"uint256\", \"name\": \"_entropy\", \"type\": \"uint256\" }], \"name\": \"commit\", \"outputs\": [], \"stateMutability\": \"nonpayable\", \"type\": \"function\" }, { \"inputs\": [{ \"internalType\": \"address\", \"name\": \"\", \"type\": \"address\" }], \"name\": \"commitments\", \"outputs\": [ { \"internalType\": \"uint256\", \"name\": \"entropy\", \"type\": \"uint256\" }, { \"internalType\": \"uint256\", \"name\": \"blockNumber\", \"type\": \"uint256\" } ], \"stateMutability\": \"view\", \"type\": \"function\" }, { \"inputs\": [], \"name\": \"reveal\", \"outputs\": [], \"stateMutability\": \"payable\", \"type\": \"function\" }, { \"stateMutability\": \"payable\", \"type\": \"receive\" } ], \"valueInWei\": \"0\", \"chain\": { \"chainId\": \"7701\", \"chainMetadata\": { \"chainName\": \"CANTO Testnet\", \"nativeCurrency\": { \"name\": \"CANTO\", \"symbol\": \"CANTO\", \"decimals\": 18 }, \"rpcUrls\": [\"https://canto-testnet.plexnode.wtf\"] } } }";
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

        UnityWebRequest request = new UnityWebRequest("localhost:9680/callContract", "POST");
        request.uploadHandler = new UploadHandlerRaw(jsonBytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
        Debug.Log(request.error);
        string response = request.downloadHandler.text;
        // if no commit then response = "{"0":"0","1":"0","entropy":"0","blockNumber":"0"}"
        Debug.Log(response);
    }
}
