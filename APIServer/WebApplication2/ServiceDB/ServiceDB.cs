using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;


namespace WebApplication2.ServiceDB
{
    public class Service
    {
        SHOPEntities1 db = new SHOPEntities1();



        public bool checkAcc(string _userName, string _passWord)
        {
            var q = (from e in db.ACCOUNTs
                     where e.Username == _userName
                     select new
                     {
                         name = e.Username,
                         pass = e.Password
                     }).ToList();
            if (q.Count == 0)
                return false;
            else
                if (q[0].pass != _passWord)
                return false;
            return true;
        }


        //Cai nay phai dieu chinh lai dataBase de dieu chinh lai khoa ngoai giua KHACHHANG, ADMIN toi ACCOUNT. Thieu mat IDACCOUT
        // lay inforAccount
        public AccInfor getAccInfor(string _userName, string _passWord)
        {
            AccInfor result = new AccInfor();
            if (checkAcc(_userName, _passWord) == false)
                return null;
            #region if have exist account
            else
            {

                var q = (from e in db.ACCOUNTs
                         where e.Username == _userName && e.Password == _passWord
                         select new
                         {
                             useName = e.Username,
                             passWord = e.Password,
                             idType = e.IDType
                         }).ToList();
                result.Username = q[0].useName;
                result.Password = q[0].passWord;
                result.IDType = q[0].idType;
                if (result.IDType == "TYP01")
                {
                    var r = (from e in db.ACCOUNTs
                             join f in db.ACCOUNTADMINs on e.Username equals f.Account
                             where e.Username == _userName && e.Password == _passWord
                             select new
                             {
                                 id = f.ID,
                                 Ten = f.Ten,
                                 Email = f.Email,
                                 SDT = f.SDT
                             }).ToList();
                    result.Ten = r[0].Ten;
                    result.SDT = r[0].SDT;
                    result.Email = r[0].Email;
                    result.ID = r[0].id.ToString();
                }
                else
                {
                    var r = (from e in db.ACCOUNTs
                             join f in db.KHACHHANGs on e.Username equals f.IDAccount
                             where e.Username == _userName && e.Password == _passWord
                             select new
                             {
                                 id = f.ID,
                                 Ten = f.Ten,
                                 Email = f.Email,
                                 SDT = f.SDT,
                                 DiaChi = f.DiaChi
                             }).ToList();
                    result.Ten = r[0].Ten;
                    result.SDT = r[0].SDT;
                    result.Email = r[0].Email;
                    result.ID = r[0].id.ToString();
                    result.DiaChi = r[0].DiaChi;
                }
            }
            #endregion
            return result;

        }

     

    }
}