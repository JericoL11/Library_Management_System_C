//libraries
using System;
using System.Security.Cryptography;
using System.Text;


namespace Library_Management_System_C.Services
{
    public class HashingService
    {
        //HASHING METHO 
        public static string HashData(string userData)
        {
            //Sha256 declaration

            using (SHA256 sha256 = SHA256.Create())
            {
                //method workers
                byte[] inputBytes = Encoding.UTF8.GetBytes(userData);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);


                //string builder   variable
                StringBuilder builder = new StringBuilder();

                for(int i =0; i < 5; i++)
                {
                    //converting of each byte to its hexadecimal representaion
                    builder.Append(hashBytes[i].ToString());
                }

                //ASSIGNING TO MAIN VAR
                return builder.ToString();
            }
        }
    }
}
