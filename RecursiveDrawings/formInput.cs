using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecursiveDrawings
{
    public partial class formInput : Form
    {
        public formInput()
        {
            InitializeComponent();
        }

        public formInput(string prompt) : this()
        {
            lblPrompt.Text = prompt;
        }

        public formInput(string prompt, string caption):this(prompt)
        {
            this.Text = caption;
        }

        public formInput(string prompt, string caption, object defaultValue):this(prompt,caption)
        {
            txtInput.Text = defaultValue.ToString();
        }

        public string Result
        {
            get
            {
                return txtInput.Text;
            }
        }
    }
}
