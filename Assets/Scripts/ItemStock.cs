using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemStock : MonoBehaviour
{
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textOwner;
    [SerializeField] private TMP_Text textCount;
    [SerializeField] private TMP_Text textPrice;
    [SerializeField] private TMP_Text textCountStarOwner;

    [SerializeField] private Image icon;
    [SerializeField] private Image iconOwner;

    private string nameStock;
    private string owner;
    private int count;
    private int price;
    private int countStarOwner; //?

    private Sprite iconSprite;
    private Sprite iconOwnerSprite;

    //TODO
    private string iconName;


    public string Name => nameStock;
    public string Owner => owner;
    public int Count => count;
    public int Price => price;
    public Sprite Icon => iconSprite;
    public Sprite IconOwner => iconOwnerSprite;
    public int CountStarOwner => countStarOwner;

    public string IconName => iconName;

    public void SetName(string name)
    {
        this.nameStock = name;
        textName.text = name;
    }

    public void SetIconName(string iconName)
    {
        this.iconName = iconName;
    }

    public void SetOwner(string owner)
    {
        this.owner = owner;
        textOwner.text = owner;
    }

    public void SetCount(int count)
    {
        this.count = count;
        textCount.text = $"x{count}";
    }

    public void SetPrice(int price)
    {
        this.price = price;
        textPrice.text = price.ToString();
    }

    public void SetIcon(Sprite iconSprite)
    {
        this.iconSprite = iconSprite;
        icon.sprite = iconSprite;

        //TODO Default
    }

    public void SetIconOwner(Sprite iconOwnerSprite)
    {
        this.iconOwnerSprite = iconOwnerSprite;
        iconOwner.sprite = iconOwnerSprite;

        //TODO Default
    }

    public void SetCountStarOwner(int countStarOwner)
    {
        this.countStarOwner = countStarOwner;
        textCountStarOwner.text = countStarOwner.ToString();
    }
}
