namespace namespace1
{
using System;
using System.Collections.Generic;

public class Testlet {
  public string TestletId;
  private List < Item > Items;

  private int FixedItems = 10;
  private int OperationalItems = 6;
  private int PretestItems = 4;
  private IRandomizeItems randomizer;

  public Testlet(string testletId, List < Item > items) {
    this.TestletId = testletId;
    this.Items = items;
    
  }
  
  private Testlet(IRandomizeItems rndmzr) {
      this.randomizer = rndmzr;
  }

  public static bool IsEmpty < T > (List < Item > list) {
    if (list == null) {
      return true;
    }

    return !list.Any();
  }

  public Testlet ValidateTestlet(string testletId, List < Item > items) {
    if (!IsEmpty(items)) {
      if (items.Count == FixedItems) {
        var itemsTypeWise = items.ToLookup(i => i.ItemType);
        bool isValid = false;
        bool PretestValidation = false;
        bool OperationalValidation = false;
        for (int i = 0; i < itemsTypeWise.Count; i++) {

          foreach(Item item1 in itemsTypeWise[i]) {
            if (item1.ItemType == ItemTypeEnum.Pretest) {
              if (itemsTypeWise[i].Count == PretestItems) {
                PretestValidation = true;
              }
            } else if (item1.ItemType == ItemTypeEnum.Operational) {
              if (itemsTypeWise[i].Count == OperationalItems) {
                OperationalValidation = true;
              }
            }
          }

        }

        if (PretestValidation == true && OperationalValidation == true) {
          isValid = true;
        }

        if (isValid == true) {
          var randomItems = this.randomizer.RandomizeItems(items);
          return new Testlet(testletId, randomItems);

        } else {
          return null;
        }

      }

      return null;

    } else {
      return null;
    }

  }

}
}
