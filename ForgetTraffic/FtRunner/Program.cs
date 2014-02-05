﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ForgetTraffic.ServicesUtils;

namespace FtRunner
{
    class Program
    {
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {

            String unprocess =
                "Master;aJDHONL29qiOvwkBHAoTcL4WTFRbeppeyrLEk34xSLfk/cNfEUf9VUSp8cxaWmbjFDxANMMm2AqzN3gxkoK+TSyW53s=;17:27;";

            ComputeResult result = ForgetTraffic.ServicesUtils.CrypytUtils.ComputeHash(unprocess, "", null);

            Console.WriteLine(result.HashValue);
                Console.ReadLine();
            }

        


        

    }
}
