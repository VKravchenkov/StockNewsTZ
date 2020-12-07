using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablesContent : MonoBehaviour
{
    [SerializeField] private List<AssetReference> stockIconReference;

    public List<AssetReference> StockIconReference => stockIconReference;
}
