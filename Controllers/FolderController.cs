using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBackend.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using RememberWhen.Models;
using RememberWhen.Models.DTO;
using RememberWhen.Properties.Services.Context;
using Microsoft.EntityFrameworkCore;
using RememberWhen.Properties.Services;

namespace RememberWhen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FolderController : ControllerBase
    {
        private readonly FolderService _data;

        public FolderController(FolderService dataFromService)
        {
            _data = dataFromService;
        }

        [HttpPost]
        [Route("AddFolder")]
        public bool AddFolder(FolderModel newFolder)
        {
            return _data.AddFolder(newFolder);
        }

        [HttpGet]
        [Route("GetFoldersByUserId/{userid}/{notDeleted}")]
        public IEnumerable<FolderModel> GetFoldersByUserId(int userid, bool notDeleted)
        {
            return _data.GetFoldersByUserId(userid, notDeleted);
        }

        [HttpPut]
        [Route("UpdateFolder")]
        public bool UpdateFolder(FolderModel FolderUpdate)
        {
            return _data.UpdateFolder(FolderUpdate);
        }

        [HttpPost]
        [Route("DeleteFolder")]
        public bool DeleteFolder(FolderModel FolderDelete)
        {
            return _data.DeleteFolder(FolderDelete);
        }

        [HttpGet]
        [Route("folderNameByFolderId/{folderId}")]
        public FolderDTO GetFolderNameByFolderId(int folderId){
            return _data.GetFolderNameByFolderId(folderId);
        }



    }
}