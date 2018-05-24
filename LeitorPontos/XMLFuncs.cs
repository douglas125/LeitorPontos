using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LeitorPontos
{
    /// <summary>Useful XML Functions</summary>
    public static class XMLFuncs
    {
        /// <summary>Creates new table</summary>
        /// <param name="TableName">Name</param>
        /// <param name="Fields">Table fields. String. Start with dbl to make doubles.</param>
        public static DataTable CreateNewTable(string TableName, string[] Fields)
        {
            DataTable t = new DataTable(TableName);
            DataColumn[] key = new DataColumn[1];
            key[0] = new DataColumn();
            key[0].DataType = System.Type.GetType("System.Int32");
            key[0].ColumnName = "Count";
            key[0].AutoIncrement = true;
            key[0].ReadOnly = true;

            t.Columns.Add(key[0]);
            t.PrimaryKey = key;

            for (int i = 0; i < Fields.Length; i++)
            {
                DataColumn c;
                if (Fields[i].StartsWith("dbl")) c = new DataColumn(Fields[i], System.Type.GetType("System.Double"));
                else c = new DataColumn(Fields[i], System.Type.GetType("System.String"));

                t.Columns.Add(c);
                c.Dispose();
            }

            return t;
        }

        
        /// <summary>Creates a column in a datatable if it does not exist and binds it to the control. 
        /// Added controls: Control name starts with txtInt: integer. Control name starts with "txt" - TextBox bound to Double. If textbox ends with "Name" - string.
        /// Control name starts with "radio" - Radio button. Boolean.
        /// Control name starts with "chk" - Check box. Boolean.
        /// Control name starts with "cmb" - Combo box. String.</summary>
        /// <param name="t">Datatable to analyze.</param>
        /// <param name="c">Control to create column from.</param>
        public static void CreateColumn(DataTable t, Control c)
        {
            if (t.Rows.Count == 0)
            {
                DataRow r = t.NewRow();
                t.Rows.Add(r);
            }

            if (c.Name.StartsWith("txt"))
            {
                TextBox tb = (TextBox)c;
                if (t.Columns.IndexOf(c.Name) < 0)
                {
                    DataColumn col = new DataColumn(c.Name);

                    //Coloca nomes como aceitando strings
                    if (c.Name.EndsWith("Name")) col.DataType = System.Type.GetType("System.String");
                    else if (c.Name.StartsWith("txtInt")) col.DataType = System.Type.GetType("System.Int32");
                    //Os demais aceitam apenas numeros
                    else col.DataType = System.Type.GetType("System.Double");

                    t.Columns.Add(col);

                    DataRow r = t.Rows[0];
                    if (tb.Text.Trim() != "") r[c.Name] = tb.Text;
                }

                tb.DataBindings.Clear();
                tb.DataBindings.Add("Text", t, c.Name, true, DataSourceUpdateMode.OnPropertyChanged);

            }
            else if (c.Name.StartsWith("radio"))
            {
                if (t.Columns.IndexOf(c.Name) < 0)
                {
                    DataColumn col = new DataColumn(c.Name);
                    col.DataType = System.Type.GetType("System.Boolean");

                    t.Columns.Add(col);
                }
                RadioButton rb = (RadioButton)c;
                rb.DataBindings.Clear();

                rb.DataBindings.Add("Checked", t, c.Name, true, DataSourceUpdateMode.OnPropertyChanged);
            }
            else if (c.Name.StartsWith("chk"))
            {
                if (t.Columns.IndexOf(c.Name) < 0)
                {
                    DataColumn col = new DataColumn(c.Name);
                    col.DataType = System.Type.GetType("System.Boolean");

                    t.Columns.Add(col);
                }
                CheckBox cb = (CheckBox)c;
                cb.DataBindings.Clear();

                cb.DataBindings.Add("Checked", t, c.Name, true, DataSourceUpdateMode.OnPropertyChanged);
            }
            else if (c.Name.StartsWith("cmb"))
            {
                if (t.Columns.IndexOf(c.Name) < 0)
                {
                    DataColumn col = new DataColumn(c.Name);
                    col.DataType = System.Type.GetType("System.String");

                    t.Columns.Add(col);
                }
                ComboBox cmb = (ComboBox)c;
                cmb.DataBindings.Clear();

                cmb.DataBindings.Add("Text", t, c.Name, true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        /// <summary>Creates a table containing a grid's structure. Sets data type based on column name: if it starts with: int -> Integer data type;
        /// string -> String data type; else -> Double.</summary>
        /// <param name="grid">DataGridView to read info from.</param>
        /// <param name="TableName">Name of table being created.</param>
        /// <param name="data">DataSet to store table.</param>
        public static DataTable MakeTableFromDataGrid(DataGridView grid, string TableName, DataSet data)
        {
            //data.Tables.Remove(TableName);

            DataTable t;
            if (data.Tables.IndexOf(TableName) < 0)
            {
                t = new DataTable(TableName);
                data.Tables.Add(t);
            }
            else t = data.Tables[TableName];

            if (t.Columns.IndexOf("Count") < 0)
            {
                DataColumn[] key = new DataColumn[1];
                key[0] = new DataColumn();
                key[0].DataType = System.Type.GetType("System.Int32");
                key[0].ColumnName = "Count";
                key[0].AutoIncrement = true;
                key[0].ReadOnly = true;

                t.Columns.Add(key[0]);
                t.PrimaryKey = key;
            }

            foreach (DataGridViewColumn c in grid.Columns)
            {
                DataColumn col = new DataColumn(c.Name);

                if (col.ColumnName.StartsWith("int")) col.DataType = System.Type.GetType("System.Int32");
                else if (col.ColumnName.StartsWith("string")) col.DataType = System.Type.GetType("System.String");
                else col.DataType = System.Type.GetType("System.Double");

                if (t.Columns.IndexOf(c.Name) < 0)
                {
                    t.Columns.Add(col);
                }
                t.Columns[c.Name].Caption = c.HeaderText;
            }

            if (grid.DataSource == null) grid.Columns.Clear();

            grid.DataSource = t;
            grid.Columns["Count"].Visible = false;

            foreach (DataGridViewColumn c in grid.Columns)
                c.HeaderText = t.Columns[c.Name].Caption;

            return t;
        }

        /// <summary>Class to read text files.</summary>
        public static class FileReader
        {
            /// <summary>Reads a text file and stores its lines in string arrays.</summary>
            /// <param name="FileName">File to read</param>
            public static List<string[]> ReadFile(string FileName)
            {
                List<string[]> resp = new List<string[]>();

                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(FileName);
                    string linha;

                    //Le dados
                    while (!sr.EndOfStream)
                    {
                        linha = sr.ReadLine();
                        linha = FileReader.Trata(linha);

                        string[] texto = linha.Split();
                        resp.Add(texto);
                    }

                    sr.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }

                return resp;

            }

            private static string Trata(string linha)
            {
                string sepDec = (1.5).ToString().Substring(1, 1);

                linha = linha.Replace(".", sepDec);
                linha = linha.Replace(",", sepDec);
                linha = linha.Trim().Replace("     ", " ");
                linha = linha.Replace("    ", " ");
                linha = linha.Replace("   ", " ");
                linha = linha.Replace("  ", " ");
                return linha;
            }

        }
    }
}
