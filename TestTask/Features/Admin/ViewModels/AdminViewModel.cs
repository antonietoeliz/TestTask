using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TestTask.Features.Admin.ViewModels
{
    public class AdminViewModel
    {
        public AdminViewModel()
        {

        }
        public bool ComprobarContraseña(string contraseñaIntroducida)
        {
            string contrasenaAlmacenada = "59e7bc4a93901a909703506ae7ee5d2052af8545430aca7c35e4f553ba49b7e0";
            return contrasenaAlmacenada == ComputeSHA256Hash(contraseñaIntroducida);
        }

        private string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}