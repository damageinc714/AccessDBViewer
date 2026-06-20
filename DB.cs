using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace AccessDBViewer
{
    public static class DB
    {
        public static string connectString;

        public static OleDbConnection MyConnect;

        public static OleDbDataAdapter dataAdapter;

        public static OleDbCommandBuilder builder;

        public static DataSet ds;

        public static DataTable dt;

        public static void OpenConnect()
        {
            if (MyConnect == null)
            {
                MyConnect = new OleDbConnection(connectString);
            }

            if (MyConnect.State != ConnectionState.Open)
            {
                MyConnect.Open();
            }
        }

        public static void CloseConnect()
        {
            if (MyConnect != null && MyConnect.State == ConnectionState.Open)
            {
                MyConnect.Close();
            }
        }

        public static void OpenTable(string tableName)
        {
            dataAdapter = new OleDbDataAdapter("SELECT * FROM [" + tableName + "]", MyConnect);

            builder = new OleDbCommandBuilder(dataAdapter);

            dataAdapter.UpdateCommand = builder.GetUpdateCommand();

            dataAdapter.InsertCommand = builder.GetInsertCommand();

            dataAdapter.DeleteCommand = builder.GetDeleteCommand();

            ds = new DataSet();

            dataAdapter.Fill(ds);

            dt = ds.Tables[0];
        }

        public static void SaveData()
        {
            if (ds != null && ds.Tables.Count > 0)
            {
                dataAdapter.Update(ds.Tables[0]);
            }
        }

        public static void CreateQuery(string command)
        {
            dataAdapter = new OleDbDataAdapter(command, MyConnect);
            ds = new DataSet();
            dataAdapter.Fill(ds);
        }

        public static void WriteReport(DataTable DT)
        {
            Word.Document wordDocument;

            var wordApp = new Word.Application();

            wordApp.Caption = "Отчет";
            wordApp.Visible = true;

            object template = Type.Missing;
            object newTemplate = false;
            object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
            object visible = true;

            wordDocument = wordApp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);

            object start = 0;
            object end = 0;

            Word.Range wordRange = wordDocument.Range(ref start, ref end);

            wordRange.Text = DateTime.Today.ToString();

            Word.Range tableRange = wordDocument.Range(ref start, ref end);

            object defaultTableBehavior = Word.WdDefaultTableBehavior.wdWord9TableBehavior;

            object autoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitWindow;

            Word.Table wordTable = wordDocument.Tables.Add(tableRange, DT.Rows.Count + 1, DT.Columns.Count, ref defaultTableBehavior, ref autoFitBehavior);

            Word.Range cellRange;

            for (int i = 0; i < DT.Columns.Count; i++)
            {
                cellRange = wordTable.Cell(1, i + 1).Range;
                cellRange.Text = DT.Columns[i].Caption;
            }

            for (int row = 0; row < DT.Rows.Count; row++)
            {
                for (int col = 0; col < DT.Columns.Count; col++)
                {
                    cellRange = wordTable.Cell(row + 2, col + 1).Range;
                    cellRange.Text = DT.Rows[row][col].ToString();
                }
            }
        }
    }
}
