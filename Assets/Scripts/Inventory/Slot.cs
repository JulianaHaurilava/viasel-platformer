using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool IsEmpty;

    [SerializeField]
    private Image image;

    private Item _item;

    public void SetItem(Item item)
    {
        image.sprite = item.Sprite;
        SetAlpha(1f);

        _item = item;
        _item.transform.parent = transform;
        _item.transform.localPosition = Vector3.zero;

        IsEmpty = false;
    }
    public void RemoveItem()
    {
        SetAlpha(0f);

        _item = null;

        IsEmpty = true;
    }

    private void SetAlpha(float alpha)
    {
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }
}
