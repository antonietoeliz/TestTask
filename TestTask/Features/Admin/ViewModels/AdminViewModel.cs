﻿using System;
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
            string contrasenaAlmacenada = "hash";
            return contrasenaAlmacenada == ComputeSHA256Hash(contrasenaAlmacenada);
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