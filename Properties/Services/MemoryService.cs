using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RememberWhen.Models;
using RememberWhen.Properties.Services.Context;

namespace RememberWhen.Properties.Services
{
  public class MemoryService
    {
      private readonly DataContext _context;
      public MemoryService(DataContext context)
      {
        _context = context;
        
      }
          public bool  AddMemoryItem(MemoryItemModel newMemoryItem)
        {
          _context.Add(newMemoryItem);
          return _context.SaveChanges() != 0;
            
        } 

           public IEnumerable<MemoryItemModel> GetAllMemoryItems()
        {

            return _context.MemoryInfo;
        }


        public IEnumerable<MemoryItemModel> GetItemsByUserId(int userId)
        {
          return _context.MemoryInfo.Where(item => item.UserID  == userId );
            
        }

        public IEnumerable<MemoryItemModel> GetItemsByCategory(string category)
        {

            return _context.MemoryInfo.Where(item => item.Category == category);
        }


        public IEnumerable<MemoryItemModel> GetItemsByDate(string date)
        {

          return _context.MemoryInfo.Where(item => item.Date == date);
            
        }


              public IEnumerable<MemoryItemModel> GetPublishedItems()
        {
          return _context.MemoryInfo.Where(item => item.isPublished);

            
        }

           public List<MemoryItemModel> GetItemsByTag(string Tag)
        {
            List<MemoryItemModel> AllMemorysWithTag = new List<MemoryItemModel>();

            var allItems = GetAllMemoryItems().ToList();

            for(int i = 0; i < allItems.Count;  i++)
            {
              MemoryItemModel Item = allItems[i];
              var itemArr = Item.Tags.Split(",");

              for(int j = 0; j < itemArr.Length; j++)
              {
                if(itemArr[j].Contains(Tag))
                {
                  AllMemorysWithTag.Add(Item);
                }
              } 


            }
            return AllMemorysWithTag;
        }


         public MemoryItemModel GetMemoryItemById(int id)
        {
            return _context.MemoryInfo.SingleOrDefault(item => item.Id == id);
        }


         public bool UpdateMemoryItem(MemoryItemModel MemoryUpdate)
        {
            _context.Update<MemoryItemModel>(MemoryUpdate);
            return _context.SaveChanges() != 0;
        }


          public bool DeleteMemoryItem(MemoryItemModel MemoryDelete)
        {
            MemoryDelete.isDeleted = true;
            _context.Update<MemoryItemModel>(MemoryDelete);
            return _context.SaveChanges() != 0;
        }
    }
}