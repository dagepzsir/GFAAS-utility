using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using System.Windows.Forms;

namespace SpectrAA_DATA_to_Excel
{
    class Exporter
    {
        private static string getTableName(string[] str)
        {
            string output = "";
            output = str[0] + " " + str[2];
            return output;
        }

        public static void ExportToXls(string file, string outputFolder = "", ProgressBar bar = null)
        {

            XLWorkbook workbook = new XLWorkbook();
            IXLWorksheet ws =  workbook.Worksheets.Add("munkalap1");
            using(StreamReader reader = new StreamReader(file))
            {
                string[] firstLine = reader.ReadLine().Split(',');
                ws.Cell(1, 1).Value = getTableName(firstLine);
                ws.Cell(1, 2).Value = "I";
                ws.Cell(1, 3).Value = "I0";
                int oszlopI = 2;
                int oszlopI0 = 3;
                int sor = 2;
                while(!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    if(temp.Contains(firstLine[0]))
                    {
                        oszlopI += 4;
                        oszlopI0 += 4;
                        ws.Cell(1, oszlopI - 1).Value = getTableName(temp.Split(','));
                        ws.Cell(1, oszlopI).Value = "I";
                        ws.Cell(1, oszlopI0).Value = "I0";
                        ws.Cell(1, oszlopI0 + 1).Value = "ABS";
                        sor = 2;
                    }
                    else
                    {
                        string[] data = temp.Split(' ');
                        string adat = data[1].Remove(data[1].Length - 1, 1);
                        double decI = double.Parse(adat);
                        double decI0 = double.Parse(data[2]);

                        ws.Cell(sor, oszlopI).Value = decI;
                        ws.Cell(sor, oszlopI0).Value = decI0;
                        ws.Cell(sor, oszlopI0 + 1).Value = -Math.Log10(decI / decI0);
                        sor++;
                    }
                }
                if (bar != null)
                    bar.Value++;
            }

            FileInfo info = new FileInfo(file);
            if (outputFolder == "")
            {
                string savePath = string.Format(@"{0}\{1}.xlsx", info.Directory, info.Name.Replace(".DATA", ""));
                workbook.SaveAs(savePath);
            }
            else
            {
                string savePath = string.Format(@"{0}\{1}.xlsx", outputFolder, info.Name.Replace(".DATA", ""));
                workbook.SaveAs(savePath);
            }
        }
    }
}
