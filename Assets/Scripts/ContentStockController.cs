using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ContentStockController : MonoBehaviour
{
    [SerializeField] private GameObject prefabItem;
    [SerializeField] private GameObject grid;

    [SerializeField] private JsonCreator jsonCreator;
    [SerializeField] private AddressablesContent addressablesContent;

    [SerializeField] private List<GameObject> listItems;

    private void Start()
    {
        ShowContentStock();
    }

    private void ShowContentStock()
    {
        //Loading json
        jsonCreator.LoadJson();
        JsonContent jsonContent = jsonCreator.JsonContent;

        listItems = new List<GameObject>();

        for (int i = 0; i < jsonContent.NumberStock; i++)
        {
            GameObject gameObject = Instantiate(prefabItem, grid.transform);

            gameObject.GetComponent<ItemStock>().SetName(jsonContent.listItems[i].Name);
            gameObject.GetComponent<ItemStock>().SetOwner(jsonContent.listItems[i].NameOwner);
            gameObject.GetComponent<ItemStock>().SetPrice(jsonContent.listItems[i].Price);
            gameObject.GetComponent<ItemStock>().SetCount(jsonContent.listItems[i].Count);
            gameObject.GetComponent<ItemStock>().SetIconName(jsonContent.listItems[i].Name);

            gameObject.GetComponent<ItemStock>().SetCountStarOwner(jsonContent.listItems[i].CountStarOwner);

            addressablesContent.StockIconReference
                .Find(item => item.SubObjectName == jsonContent.listItems[i].NameIcon)
                .LoadAssetAsync<Sprite>().Completed += SpriteLoaded;


            // TODO 64String ownerIcon convert to Sprite
            Texture2D texture2D = new Texture2D(jsonContent.listItems[i].width, jsonContent.listItems[i].height);

            texture2D.LoadImage(System.Convert.FromBase64String(jsonContent.listItems[i].IconOwnerDataBase64String));
            texture2D.Apply();

            Sprite spriteOwner = Sprite.Create(
                texture2D,
                new Rect(0, 0, jsonContent.listItems[i].width, jsonContent.listItems[i].height),
                new Vector2(0.5f, 0.5f));

            gameObject.GetComponent<ItemStock>().SetIconOwner(spriteOwner);

            listItems.Add(gameObject);

        }
    }

    private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
    {
        switch (obj.Status)
        {
            case AsyncOperationStatus.None:
                break;
            case AsyncOperationStatus.Succeeded:
                listItems.FindAll(item => item.GetComponent<ItemStock>().IconName == obj.Result.name)
                         .ForEach(itemStock => itemStock.GetComponent<ItemStock>().SetIcon(obj.Result));
                break;
            case AsyncOperationStatus.Failed:
                break;
            default:
                break;
        }
    }
}
