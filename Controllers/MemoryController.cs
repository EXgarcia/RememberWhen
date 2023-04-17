using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RememberWhen.Models;
using RememberWhen.Properties.Services;

namespace RememberWhen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryController : ControllerBase
    {
        private readonly MemoryService _data;
        public MemoryController(MemoryService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddMemoryItem")]
        public bool AddMemoryItem(MemoryItemModel newMemoryItem)
        {
            return _data.AddMemoryItem(newMemoryItem);
        }

        [HttpGet]
        [Route("GetAllMemoryItems")]
        public IEnumerable<MemoryItemModel> GetAllMemoryItems()
        {
            return _data.GetAllMemoryItems();
        }

        [HttpGet]
        [Route("GetItemsByUserId/{UserId}")]
        public IEnumerable<MemoryItemModel> GetItemsByUserId(int userid)
        {
            return _data.GetItemsByUserId(userid);
        }

        [HttpGet]
        [Route("GetItemsByCategory/{category}")]
        public IEnumerable<MemoryItemModel> GetItemsByCategory(string category)
        {

            return _data.GetItemsByCategory(category);
        }

        [HttpGet]
        [Route("GetItemsByDate/{date}")]
        public IEnumerable<MemoryItemModel> GetItemsByDate(string date)
        {
            return _data.GetItemsByDate(date);
        }

        [HttpGet]
        [Route("GetPublishedItems")]
        public IEnumerable<MemoryItemModel> GetPublishedItems()
        {

            return _data.GetPublishedItems();
        }

        [HttpGet]
        [Route("GetItemsByTag/{Tag}")]
        public List<MemoryItemModel> GetItemsByTag(string Tag)
        {
            return _data.GetItemsByTag(Tag);
        }

        [HttpGet]
        [Route("GetMemoryItemById/{id}")]
        public MemoryItemModel GetMemoryItemById(int id)
        {
            return _data.GetMemoryItemById(id);
        }


        [HttpPost]
        [Route("UpdateMemoryItem")]
        public bool UpdateMemoryItem(MemoryItemModel MemoryUpdate)
        {
            return _data.UpdateMemoryItem(MemoryUpdate);
        }

        [HttpPost]
        [Route("DeleteMemoryItem")]
        public bool DeleteMemoryItem(MemoryItemModel MemoryDelete)
        {
            return _data.DeleteMemoryItem(MemoryDelete);
        }

        [HttpGet]
        [Route("GetItemsByFolderId/{folderId}")]
        public IEnumerable<MemoryItemModel> GetItemsByFolderId(int folderId)
        {
            return _data.GetItemsByFolderId(folderId);
        }


    }


}