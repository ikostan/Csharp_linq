using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTeam3
{
    public partial class WaitDialogForm : Form
    {
        /// <summary>
        /// Create Wait Form Dialog 
        /// </summary>
        //public Action Worker { get; set; }

        public WaitDialogForm()
        {
            InitializeComponent();

        //    //if (worker == null)
        //    //{
        //    //    throw new ArgumentException();
        //    //}

        //    //Worker = worker;
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    Task.Factory.StartNew(Worker).ContinueWith((t) => { this.Close(); }, 
        //        TaskScheduler.FromCurrentSynchronizationContext());
        //}

    }
}
