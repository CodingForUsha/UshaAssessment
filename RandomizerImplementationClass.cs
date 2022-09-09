namespace namespace1 {
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class Randomizer: IRandomizeItems {
    private int numberOfFirstPretestItems;

    public Randomizer(int numberOfFirstPretestItems) {
      this.numberOfFirstPretestItems = numberOfFirstPretestItems;
      this.random = new Random();
    }

    public bool IsEmpty < T > (List < Item > list) {
      if (list == null) {
        return true;
      }

      return !list.Any();
    }

    public void Swap < T > (this IList < T > items, int i, int j) {
      if (i == j) {
        return;
      }

      var tmp = items[i];
      items[i] = items[j];
      items[j] = tmp;
    }

    public List < Item > RandomizeItems(List < Item > items) {
      try {
        if (!IsEmpty(items)) {
          var mixedItems = this.mixedItems(items);

          this.PretestItemsAsStart(mixedItems);

          return mixedItems;

        } else {
          return null;
        }
      } catch (Exception e) {
        Console.WriteLine("Exception. {0}", ex.Message);
      }
    }

    private List < Item > mixedItems(IEnumerable < Item > items) {
      try {
        var mixedItems = items.ToList();

        for (var i = mixedItems.Count - 1; i >= 0; i--) {
          int randomIndex = this.random.Next(i + 1);
          mixedItems.Swap(randomIndex, i);
        }

        return mixedItems;

      } catch (Exception e) {
        Console.WriteLine("Exception. {0}", ex.Message);
      }
    }

    private void PretestItemsAsStart(IList < Item > items) {
      var PretestItemsToMoveToBeginning = 0;
      for (int i = 0; i < items.Count; i++) {
        if (items[i].Type != ItemType.Pretest) {
          continue;
        }

        items.Swap(i, PretestItemsToMoveToBeginning++);

        if (PretestItemsToMoveToBeginning >= this.numberOfFirstPretestItems) {
          break;
        }
      }
    }
  }
}
