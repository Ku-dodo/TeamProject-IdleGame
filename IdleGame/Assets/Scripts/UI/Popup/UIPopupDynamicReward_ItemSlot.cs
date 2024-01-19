using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIPopupDynamicReward_ItemSlot : MonoBehaviour
{
    #region Fields

    private Image _icon;

    #endregion

    #region Initialize

    private void Awake()
    {
        _icon = transform.Find("ItemIcon").GetComponent<Image>();
    }

    public void UpdateSlot(int index)
    {
        _icon.sprite = Manager.Resource.GetSprite(index.ToString());
    }

    public void SlotClear()
    {
        _icon.sprite = null;
    }

    #endregion
}
