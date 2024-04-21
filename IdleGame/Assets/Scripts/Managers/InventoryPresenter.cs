using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPresenter
{
    #region ItemData Control Method

    /// <summary>
    /// equipItem로 전달받은 아이템을 착용합니다.
    /// </summary>
    /// <param name="equipItem"></param>
    public void ChangeEquipmentItem(UserItemData equipItem)
    {
        if ((equipItem.hasCount == 0 && equipItem.level == 1))
        {
            SystemAlertFloating.Instance.ShowMsgAlert(MsgAlertType.CanNotEquip);
            return;
        }

        //아이템 리스트를 순회하며, 장착 상태를 false로 변경합니다.
        if (equipItem.itemID[0] == 'W')
        {
            foreach (var item in Manager.Data.WeaponItemList)
            {
                item.equipped = false;
            }
        }
        else if (equipItem.itemID[0] == 'A')
        {
            foreach (var item in Manager.Data.ArmorItemList)
            {
                item.equipped = false;
            }
        }

        //파라미터로 전달 받은 아이템 장착 상태를 true로 변경합니다.
        equipItem.equipped = true;
    }

    //강화 로직
    private void ReinforceItem(UserItemData itemdata)
    {
        var list = new List<UserItemData>();

        if ((itemdata.itemID[0] == 'W'))
        {
            list = Manager.Data.WeaponInvenList;
        }
        else
        {
            list = Manager.Data.ArmorInvenList;
        }

        while (itemdata.hasCount >= Mathf.Min(itemdata.level + 1, 15))
        {
            if (itemdata.level < 100)
            {
                itemdata.hasCount -= Mathf.Min(itemdata.level + 1, 15);
                itemdata.level += 1;
            }
            else
            {
                int index = list.FindIndex(item => item.itemID == itemdata.itemID);
                if (list.Count - 1 > index)
                {
                    itemdata.hasCount -= Mathf.Min(itemdata.level + 1, 15);
                    list[index + 1].hasCount += 1;
                }
                else if (list.Last().level < 100)
                {
                    itemdata.hasCount -= Mathf.Min(itemdata.level + 1, 15);
                    list[index + 1].hasCount += 1;
                }
                else
                {
                    break;
                }
            }
        }
    }

    /// <summary>
    /// itemdata로 전달받은 아이템을 강화합니다.
    /// </summary>
    /// <param name="itemdata"></param>
    public void ReinforceSelectItem(UserItemData itemdata)
    {
        if (itemdata.hasCount < Mathf.Min(itemdata.level + 1, 15))
        {
            SystemAlertFloating.Instance.ShowMsgAlert(MsgAlertType.CanNotReinforce);
            return;
        }
        else if(itemdata.level >= 100 &(itemdata.itemID == Manager.Data.WeaponItemList.Last().itemID | itemdata.itemID == Manager.Data.ArmorItemList.Last().itemID))
        {
            SystemAlertFloating.Instance.ShowMsgAlert(MsgAlertType.ItemLimitLevel);
            return;
        }
        ReinforceItem(itemdata);
    }

    /// <summary>
    /// itemList로 전달받은 아이템을 강화합니다.
    /// </summary>
    /// <param name="itemList"></param>
    public void ReinforceSelectTypeItem(List<UserItemData> itemList)
    {
        var list = itemList.Where(item => item.hasCount >= Mathf.Min(item.level + 1, 15)) ;

        if (list.Count() == 0 || (list.First().level >= 100 & list.First().itemID == itemList.Last().itemID))
        {
            SystemAlertFloating.Instance.ShowMsgAlert(MsgAlertType.CanNotAllReinforce);
            return;
        }
        
        foreach (var item in itemList)
        {
            ReinforceItem(item);
        }
    }

    #endregion
}