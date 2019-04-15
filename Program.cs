using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace binToArray
{
    class Program
    {
        //! filein fileout
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("bintoarray filein fileout" );
                return;
            }

            FileStream fileIn = new FileStream(args[0], FileMode.Open, FileAccess.Read);
            FileStream fileOut = new FileStream(args[1], FileMode.Create, FileAccess.Write);

            byte[] ary = new byte[ fileIn.Length ];
            fileIn.Read(ary, 0, ary.Length );

            StreamWriter writer = new StreamWriter( fileOut );

            int i = 0;
            foreach (byte dat in ary)
            {
                writer.Write(String.Format("0x{0:x},", dat));
                i++;

                if (i % 8 == 0)
                {
                    writer.WriteLine();
                }
            }

            writer.Flush();
            fileOut.Close();
        }
    }
}
