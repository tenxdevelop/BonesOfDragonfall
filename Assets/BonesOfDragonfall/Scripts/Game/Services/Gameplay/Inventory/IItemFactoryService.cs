/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace BonesOfDragonfall
{
    public interface IItemFactoryService : IDisposable
    {
        IItemModel CreateItemModel(int itemId);

        ItemData GetItemData(IItemModel itemModel);
    }
}