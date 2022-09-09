using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Namespace1.Tests {
  [TestClass]
  public class UnitTestClass{

    [TestMethod]
public void Randomizer_returns_2_pretest_and_6_operational()
        {
            var randomizer = new Randomizer();
      List < Item > ItemList = new List < Item > ();
      ItemList.Add(1, ItemTypeEnum.Operational);
      ItemList.Add(2, ItemTypeEnum.Pretest);
      ItemList.Add(3, ItemTypeEnum.Operational);
      ItemList.Add(4, ItemTypeEnum.Operational);
      ItemList.Add(5, ItemTypeEnum.Pretest);
      ItemList.Add(6, ItemTypeEnum.Operational);
      ItemList.Add(7, ItemTypeEnum.Pretest);
      ItemList.Add(8, ItemTypeEnum.Operational);
      ItemList.Add(9, ItemTypeEnum.Operational);
      ItemList.Add(10, ItemTypeEnum.Pretest);
   var randomizedItems = randomizer.Randomize(items);
            var remainingRandomizedItemsByType = randomizedItems.Skip(2).ToLookup(i => i.ItemType);
            Assert.Equal(2, remainingRandomizedItemsByType[ItemTypeEnum.Pretest].Count());
            Assert.Equal(6, remainingRandomizedItemsByType[ItemTypeEnum.Operational].Count());
        }

    [TestMethod]
    public void GetRandomizeItems_checking_10items_in_the_list() {
      var randomizer = new Randomizer();
      //Arrange  
      List < Item > ItemList = new List < Item > ();
      ItemList.Add(1, ItemTypeEnum.Operational);
      ItemList.Add(2, ItemTypeEnum.Pretest);
      ItemList.Add(3, ItemTypeEnum.Operational);
      ItemList.Add(4, ItemTypeEnum.Operational);
      ItemList.Add(5, ItemTypeEnum.Pretest);
      ItemList.Add(6, ItemTypeEnum.Operational);
      ItemList.Add(7, ItemTypeEnum.Pretest);
      ItemList.Add(8, ItemTypeEnum.Operational);
      ItemList.Add(9, ItemTypeEnum.Operational);
      ItemList.Add(10, ItemTypeEnum.Pretest);

      String expected = new List < Item >() ;
      //Act  
      var actual = randomizer.RandomizeItems(items);
      //Assert  
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
public void List_passed_should_contain_6_operational_and_4_pretest(
            int operationalCount, 
            ItemType operationalType,
            int pretestCount, 
            ItemType pretestType)
        {
            var validator = this.CreateDefaultTestletValidator();

            var firstItems = Enumerable
                .Range(0, operationalCount)
                .Select(i => new Item { ItemType = operationalType });

            var secondItems = Enumerable
                .Range(0, pretestCount)
                .Select(i => new Item { ItemType = pretestType });

            var allItems = firstItems.Union(secondItems).ToList();

            void createTestlet() => validator.ValidateTestletCreationInput("TestletId", allItems);
            var exception = Assert.Throws<TestletCreationValidationAggregateException>(createTestlet);

            Assert.Contains(exception.Exceptions, e => e.ItemsOfType == ItemType.Pretest);
            Assert.Contains(exception.Exceptions, e => e.ItemsOfType == ItemType.Operational);
      	int expectedOperational = 6;
	int expectedPretest=4;
      //Act  
if (firstItems.Count==6 && secondItems.Count==4 ) {
	expected=1;
}
      var actual = 1;
      //Assert  
      Assert.AreEqual(expected, actual);
        }
  }
}
