using Microsoft.AspNetCore.Mvc;
namespace MVC.Controllers
{
    public class Bai2Controller : Controller
    {
    public String Reverse(String input )
    {
        if (String.IsNullOrEmpty(input))
        {
            return "Chuoi rong";
        }
        char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return $"Chuỗi đảo ngược: {new string(charArray)}";
    }
    public string Length(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "Độ dài chuỗi: 0";
            }

            return $"Độ dài của chuỗi '{input}' là: {input.Length}";
        }
    }
}