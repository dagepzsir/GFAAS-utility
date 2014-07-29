using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Threading.Tasks;

namespace ChemGuess
{
    class DatabaseConnection
    {

        private static DataTable RunQuery(string commandStr)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Adatbázis1.mdb");
            DataSet output = new DataSet();
            if (connection.State != ConnectionState.Open)
                connection.Open();

            OleDbCommand command = new OleDbCommand(commandStr, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            adapter.Fill(output);
            DataTable table = output.Tables[0];
            return table;
        }
        public static List<string> GetHelp()
        {
            List<string> output = new List<string>();
            DataTable table = RunQuery("SELECT Parancs FROM Parancsok;");
            foreach(DataRow row in table.Rows)
                output.Add(row[0].ToString());

            return output;
        }
        public static string GetHelp(string parancs)
        {
            string output;
            DataTable table = RunQuery(string.Format("SELECT Segítség FROM Parancsok WHERE Parancs = '{0}';", parancs));
            output = table.Rows[0][0].ToString();
            return output;
        }
        public static DataTable GetTable(string tableName)
        {
            return RunQuery(string.Format("Select * from {0}", tableName));
        }
        public static string Result(List<Ion> unkowns, string reagent)
        {
            string commandStr = @"SELECT TOP 1 Eredmény.Eredmény, Reakciók.Intenzitás FROM Eredmény INNER JOIN (Reagensek INNER JOIN (Ionok INNER JOIN Reakciók ON Ionok.Azonosító = Reakciók.Ion) ON Reagensek.Azonosító = Reakciók.Reagens) ON Eredmény.Azonosító = Reakciók.Eredmény WHERE(";
            foreach(Ion ion in unkowns)
            {
                if(unkowns.IndexOf(ion) == unkowns.Count -1)
                    commandStr += string.Format(@"Ionok.Jel='{0}') ", ion.Sign);
                else
                    commandStr += string.Format(@"Ionok.Jel='{0}' OR ", ion.Sign);
            }
            commandStr += string.Format(@" AND Reagensek.Képlet='{0}' ORDER BY Reakciók.Intenzitás DESC;", reagent);
            DataTable table = RunQuery(commandStr);
            string output;
            if(table.Rows.Count > 0)
                output = table.Rows[table.Rows.Count - 1][0].ToString();
            else
                output = "Nincs reakcó";
            return output;
        }

        public static List<Ion> GetReagentIons(string reagens)
        {
            List<Ion> ionok = new List<Ion>();

            DataTable table = RunQuery(string.Format("SELECT Ionok.Jel, Ionok.Név, Ionok.Töltés, Reagensek.Képlet FROM Ionok INNER JOIN Reagensek ON (Ionok.Azonosító = Reagensek.Anion) OR (Ionok.Azonosító = Reagensek.Kation) WHERE (((Reagensek.Képlet)='{0}'));", reagens));
            foreach(DataRow row in table.Rows)
            {
                ionok.Add(new Ion(row["Név"].ToString(), row["Jel"].ToString(), int.Parse(row["Töltés"].ToString())));
            }
            return ionok;
        }
    }
}