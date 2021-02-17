﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCMS.Models;

namespace LCMS.BAL.Interface
{
    public interface IBookPlaceManager
    {
        List<BookPlace> GetBookPlacesByCatalog(int catalogId);
        BookPlace GetBookPlaceById(int id);
        int Create(BookPlace bookPlace);
        int Update(BookPlace bookPlace);
        string Delete(int id);
        string CheckInBook(int id, int userId);
        string CheckOutBook(int id);
    }
}