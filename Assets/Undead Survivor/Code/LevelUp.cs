using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;
    List<Item> consumableItems = new List<Item>();
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
        foreach (Item item in items)
        {
            if(item.data.itemType == ItemData.ItemType.Heal)
            {
                consumableItems.Add(item);
            }
        }
    }

    public void Show()
    {
        Next();
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.LevelUp);
        AudioManager.instance.EffectBgm(true);
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        AudioManager.instance.EffectBgm(false);
    }

    public void Select(int index)
    {
        items[index].OnClick();
    }

    void Next()
    {
        // 레벨업 리스트를 정리합니다.
        foreach (Item item in items)
        {
            item.gameObject.SetActive(false);
        }

        // 아이템리스트복사본을 만듭니다.
        List<int> itemCopyList = new List<int>();
        for(int i = 0; i < items.Length; i++)
        {
            itemCopyList.Add(i);
        }

        int[] ran = new int[3];

        // 3개를 뽑아서 ran배열에 넣습니다.
        for(int i = 0; i < ran.Length; i++)
        {
            int pickedIdx = Random.Range(0, itemCopyList.Count);
            ran[i] = itemCopyList[pickedIdx];
            itemCopyList.RemoveAt(pickedIdx);
        }

        // 만약 아이템이 맥스레벨이면 소비아이템으로 전환합니다.
        for(int index=0; index < ran.Length; index++)
        {
            //Item ranItem = ran[index]; // 왜 이게 아니지?
            //ran[index]는 item리스트의 인덱스를 담고 있습니다. 또한 타입이 안맞습니다.
            Item ranItem = items[ran[index]];
            int maxLevel = ranItem.data.maxLevel;

            // 맥스레벨이면, 아이템을 소비아이템으로 바꾸기
            if (ranItem.level == maxLevel && ranItem.data.itemType != ItemData.ItemType.Heal)
            {
                consumableItems[Random.Range(0, consumableItems.Count)].gameObject.SetActive(true);               
            }
            else
            {
                ranItem.gameObject.SetActive(true);
            }
        }
    }
}
