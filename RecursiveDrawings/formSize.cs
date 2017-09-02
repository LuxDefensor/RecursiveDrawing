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
    public partial class formSize : Form
    {
        public formSize()
        {
            InitializeComponent();
            txtWidth.TextChanged += TxtWidth_TextChanged;
            txtHeight.TextChanged += TxtHeight_TextChanged;
        }

        private void TxtHeight_TextChanged(object sender, EventArgs e)
        {
            int height;
            if (Ratio != 0)
                if (int.TryParse(txtHeight.Text, out height))
                    txtWidth.Text = (height * Ratio).ToString();
        }

        private void TxtWidth_TextChanged(object sender, EventArgs e)
        {
            int width;
            if (Ratio != 0)
                if (int.TryParse(txtWidth.Text, out width))
                    txtHeight.Text = (width / Ratio).ToString();
        }

        

        public new int Width
        {
            get
            {
                int width;
                if (int.TryParse(txtWidth.Text, out width))
                    return width;
                else
                    return 0;
            }
        }

        public new int Height
        {
            get
            {
                int height;
                if (int.TryParse(txtHeight.Text, out height))
                    return height;
                else
                    return 0;
            }
        }

        public float Ratio
        {
            get
            {
                if (opt169.Checked)
                    return 16 / 9f;
                else if (opt1610.Checked)
                    return 1.6f;
                else if (opt43.Checked)
                    return 4 / 3f;
                else if (opt11.Checked)
                    return 1;
                else
                    return 0;
            }
        }
    }
}
