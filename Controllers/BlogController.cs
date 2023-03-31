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
    public class BlogController : ControllerBase
    {
        private readonly BlogService _data;
        public BlogController(BlogService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddBlogItem")]
        public bool AddBlogItem(BlogItemModel newBlogItem)
        {
            return _data.AddBlogItem(newBlogItem);
        }

        [HttpGet]
        [Route("GetAllBlogItems")]
        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _data.GetAllBlogItems();
        }

        [HttpGet]
        [Route("GetItemsByUserId/{UserId}")]
        public IEnumerable<BlogItemModel> GetItemsByUserId(int userid)
        {
            return _data.GetItemsByUserId(userid);
        }

        [HttpGet]
        [Route("GetItemsByCategory/{category}")]
        public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
        {

            return _data.GetItemsByCategory(category);
        }

        [HttpGet]
        [Route("GetItemsByDate/{date}")]
        public IEnumerable<BlogItemModel> GetItemsByDate(string date)
        {
            return _data.GetItemsByDate(date);
        }

        [HttpGet]
        [Route("GetPublishedItems")]
        public IEnumerable<BlogItemModel> GetPublishedItems()
        {

            return _data.GetPublishedItems();
        }

        [HttpGet]
        [Route("GetItemsByTag/{Tag}")]
        public List<BlogItemModel> GetItemsByTag(string Tag)
        {
            return _data.GetItemsByTag(Tag);
        }

        [HttpGet]
        [Route("GetBlogItemById/{id}")]
        public BlogItemModel GetBlogItemById(int id)
        {
            return _data.GetBlogItemById(id);
        }


        [HttpPost]
        [Route("UpdateBlogItem")]
        public bool UpdateBlogItem(BlogItemModel BlogUpdate)
        {
            return _data.UpdateBlogItem(BlogUpdate);
        }

        [HttpPost]
        [Route("DeleteBlogItem")]
        public bool DeleteBlogItem(BlogItemModel BlogDelete)
        {
            return _data.DeleteBlogItem(BlogDelete);
        }

    }


}