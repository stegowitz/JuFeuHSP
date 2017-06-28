using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuFeuDatenbank
{
    public partial class NeuesMitglied : Form
    {
        Datenbank db;

        public NeuesMitglied(Datenbank d)
        {
            InitializeComponent();

            db = d;
        }
    }
}
