using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace JuFeuDatenbank
{

    public partial class Mitgliederliste : Form
    {
        Datenbank db;

        public Mitgliederliste(Datenbank d)
        {
            InitializeComponent();

            db = d;

            ListeAnzeigen();

            dataGridView1.Columns["Nummer"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Vorname"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Nachname"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void ListeAnzeigen()
        {
            string sql = "select * from mitglieder order by id asc";

            SQLiteCommand command = new SQLiteCommand(sql, db.getConnection());
            SQLiteDataReader reader = command.ExecuteReader();

            string[] row;

            while (reader.Read())
            {
                row = new string[] { reader["id"].ToString(), reader["name"].ToString(), reader["vorname"].ToString() };
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeuesMitglied nm = new NeuesMitglied(db);
            nm.ShowDialog();

            ListeAnzeigen();
        }
    }
}
