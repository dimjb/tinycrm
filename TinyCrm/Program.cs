using System;

namespace TinyCrm
{
      class Program
      {
            static void Main(string[] args)
            {
                  Console.WriteLine(IsAdult(12));
                  Console.WriteLine(IsValidAfm("123d56789"));
                  Console.WriteLine(IsValidEmail("asd@test.com"));
            }

            public static bool IsAdult(int age)
            {
                  return age >= 18 && age <= 110;
            }

            public static bool IsValidAfm(string afm)
            {
                  if (string.IsNullOrWhiteSpace(afm)) return false;
                  afm = afm.Trim();

                  foreach (char ch in afm)
                  {
                        if (!char.IsDigit(ch)) return false;
                  }

                  return afm.Length == 9;
            }

            public static bool IsValidEmail(string email)
            {
                  if (string.IsNullOrWhiteSpace(email)) return false;
                  email = email.Trim();

                  int count = 0;
                  foreach (char ch in email)
                  {
                        if (ch == '@') count++;
                  }

                  return count == 1 && (email.EndsWith(".com") || email.EndsWith(".gr"));
            }
      }
}
