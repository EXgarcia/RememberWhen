using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RememberWhen.Models;
using RememberWhen.Models.DTO;
using RememberWhen.Properties.Services.Context;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using blogBackend.Models.DTO;

namespace RememberWhen.Properties.Services
{
    public class FolderService
    {
        private readonly DataContext _context;
        public FolderService(DataContext context)
        {
            _context = context;
        }
      public bool DoesFolderExist(string? FolderName, int userId, bool notDeleted)
        {
            return _context.FolderInfo.SingleOrDefault(folder => folder.Name == FolderName && folder.userId == userId && folder.isDeleted == notDeleted) != null;
        }
        public bool AddFolder(FolderModel newFolder)
        {
            bool result = false;
            if (!DoesFolderExist(newFolder.Name, newFolder.userId, newFolder.isDeleted))
            {
                _context.Add(newFolder);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public IEnumerable<FolderModel> GetFoldersByUserId(int userId, bool notDeleted)
        
        {
            return _context.FolderInfo.Where(folder => folder.userId == userId && folder.isDeleted == notDeleted);

        }

       public bool UpdateFolder(FolderModel FolderUpdate)
        {
            bool result = false;
            if (!DoesFolderExist(FolderUpdate.Name, FolderUpdate.userId, FolderUpdate.isDeleted))
            {
                _context.Update<FolderModel>(FolderUpdate);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public bool DeleteFolder(FolderModel FolderDelete)
        {
            FolderDelete.isDeleted = true;
            _context.Update<FolderModel>(FolderDelete);
            return _context.SaveChanges() != 0;
        }

        public FolderDTO GetFolderNameByFolderId(int folderId){
            var FolderInfo = new FolderDTO();
            var foundFolder = _context.FolderInfo.SingleOrDefault(folder => folder.FolderId == folderId);
            FolderInfo.FolderId = foundFolder.FolderId;
            FolderInfo.FolderName = foundFolder.FolderName;
            return FolderInfo;

        }

        // public UserIdDTO GetUserIdDTOByUsername(string username)
        // {
        //     var UserInfo = new UserIdDTO();
        //     var foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);
        //     UserInfo.UserId = foundUser.Id;
        //     UserInfo.PublisherName = foundUser.Username;
        //     return UserInfo;
        // }

    }
}