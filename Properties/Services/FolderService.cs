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
        public bool AddFolder(FolderModel newFolder)
        {
            _context.Add(newFolder);
            return _context.SaveChanges() != 0;

        }

        public IEnumerable<FolderModel> GetFoldersByUserId(int userId)
        {
            return _context.FolderInfo.Where(folder => folder.userId == userId);

        }

        public bool UpdateFolder(FolderModel FolderUpdate)
        {
            _context.Update<FolderModel>(FolderUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool DeleteFolder(FolderModel FolderDelete)
        {
            FolderDelete.isDeleted = true;
            _context.Update<FolderModel>(FolderDelete);
            return _context.SaveChanges() != 0;
        }

    }
}