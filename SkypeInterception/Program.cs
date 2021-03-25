using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Skype_to_Dialer
{
    class SkypeDialer
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string checkme = args[0];
                if (checkme.CompareTo("--") == 0)
                {
                    checkme = args[1];
                }
                string pattern = @"\d+";
                Match m = Regex.Match(checkme, pattern, RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    Console.WriteLine(m.Groups[0].Value);
                    var url = "tel:" + m.Groups[0].Value;
                    var psi = new ProcessStartInfo();
                    psi.UseShellExecute = true;
                    psi.FileName = url;

                    Process.Start(psi);
                }
            }
        }

    }
}