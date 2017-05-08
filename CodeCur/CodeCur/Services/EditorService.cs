﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCur.Models.Entities;
using CodeCur.Models;

namespace CodeCur.Services
{
    public class EditorService
    {
        public static File GetFile(int ID)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            File file = (from item in _db.Files
                         where item.ID == ID
                         select item).SingleOrDefault();
            return file;
        }

        public static void SaveFile(string content, int fileID)
        {
            ApplicationDbContext _db = new ApplicationDbContext();
            if (fileID != 0)
            {
                File file = (from item in _db.Files
                             where item.ID == fileID
                             select item).SingleOrDefault();
                file.Data = content;

                // Success check?
                _db.SaveChanges();
            }
            
        }
    }
}