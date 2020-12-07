using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class JsonCreator : MonoBehaviour
{
    [SerializeField] private int numberContent;
    [SerializeField] private AddressablesContent addressablesContent;

    private JsonContent jsonContent;

    [SerializeField] private List<Sprite> sprites;

    public JsonContent JsonContent => jsonContent;

    private void Start()
    {
        //LoadIconsOwnerSprite("TestIconsOwner/");
    }

    public void Create()
    {
        JsonContent jsonContent = new JsonContent();

        jsonContent.NumberStock = numberContent;
        jsonContent.listItems = new List<ItemContent>();

        for (int i = 0; i < numberContent; i++)
        {
            AssetReference assetReference = addressablesContent.StockIconReference[Random.Range(0, addressablesContent.StockIconReference.Count)];

            Sprite sprite = sprites[Random.Range(0, sprites.Count)];

            ItemContent itemContent = new ItemContent
            {
                Name = assetReference.SubObjectName,
                Count = Random.Range(0, 100),
                CountStarOwner = Random.Range(0, 100),
                NameIcon = assetReference.SubObjectName,
                NameOwner = $"Owner_{Random.Range(0, 100)}_{Random.Range(0, 100)}",
                Price = Random.Range(0, 1000),            
                IconOwnerDataBase64String = System.Convert.ToBase64String(sprite.texture.EncodeToPNG()),
                width = sprite.texture.width,
                height = sprite.texture.height
            };

            jsonContent.listItems.Add(itemContent);
        }
        string json = JsonUtility.ToJson(jsonContent);

        Save(string.Empty, json);
    }

    //TODO Testing
    public void LoadJson()
    {
        //jsonContent = Load(Application.persistentDataPath + "/JconContent.json");
        var jsonFile = Resources.Load<TextAsset>("JconContent");

        jsonContent = JsonUtility.FromJson<JsonContent>(jsonFile.ToString());
    }

    public void Clear()
    {

    }

    private void Save(string path, string json)
    {
        File.WriteAllText(Application.persistentDataPath + "/JconContent.json", json);
    }

    // TODO testing
    private void LoadIconsOwnerSprite(string path)
    {
        sprites = Resources.LoadAll<Sprite>(path).ToList();
    }
}
