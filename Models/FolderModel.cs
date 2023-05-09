using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RememberWhen.Models
{
    public class FolderModel
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public int FolderId { get; internal set; }
        public string? FolderName { get; internal set; }

        public FolderModel() { }

    }
}