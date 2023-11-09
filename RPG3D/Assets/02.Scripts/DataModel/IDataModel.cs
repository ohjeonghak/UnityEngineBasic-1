using System;
using System.Collections;

namespace RPG.DataModel
{
    /// <summary>
    /// 데이터 모델 인터페이스
    /// </summary>
    /// <typeparam name="T">아이템 타입</typeparam>
    public interface IDataModel
    {
        IEnumerable itemIDs { get; }
        IEnumerable items { get; }
        void RequestRead(int itemID, Action<int, object> onSuccess);
        void RequestWrite(int itemID, object item, Action<int, object> onSuccess);

        void SetDefaultItems();
    }
}