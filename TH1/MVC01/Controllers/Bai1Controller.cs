using Microsoft.AspNetCore.Mvc;
using System;

namespace MVC01.Controllers
{
    public class Bai1Controller : Controller
    {
        public string Index()
        {
            return $"Thoi gian hien tai: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        public string Welcome(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Xin chao ban khong co ten";
            }
            return "Xin chao " + name;
        }
    }
}