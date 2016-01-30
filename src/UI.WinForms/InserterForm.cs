using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace UI.WinForms
{
    public partial class InserterForm : Form
    {
        private readonly IPdfInserter _pdfInserter;

        public InserterForm(IPdfInserter pdfInserter)
        {
            _pdfInserter = pdfInserter;
            InitializeComponent();
        }

    }
}
