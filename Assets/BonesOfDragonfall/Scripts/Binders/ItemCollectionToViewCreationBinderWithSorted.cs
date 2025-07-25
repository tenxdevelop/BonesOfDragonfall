/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

namespace BonesOfDragonfall
{
    public class ItemCollectionToViewCreationBinderWithSorted : VMCollectionToViewCreationBinder
    {

        public void AllSorted()
        {
            Sorted(ItemCategory.All);
        }

        public void WeaponsSorted()
        {
            Sorted(ItemCategory.Weapons);
        }

        public void ArmorsSorted()
        {
            Sorted(ItemCategory.Armors);
        }

        public void EatsSorted()
        {
            Sorted(ItemCategory.Eats);
        }

        public void ResourcesSorted()
        {
            Sorted(ItemCategory.Resources);
        }

        public void OthersSorted()
        {
            Sorted(ItemCategory.Others);
        }
        
        private void Sorted(ItemCategory itemCategorySort)
        {
            foreach (var keyValuePair in _viewMap)
            {
                var itemViewModel = keyValuePair.Key as IUIItemViewModel;
                
                if(itemViewModel.ItemCategory.Value.Equals(itemCategorySort) || itemCategorySort.Equals(ItemCategory.All))
                {
                    keyValuePair.Value.gameObject.SetActive(true);
                }
                else
                {
                    keyValuePair.Value.gameObject.SetActive(false);
                }
            }
        }
    }
}