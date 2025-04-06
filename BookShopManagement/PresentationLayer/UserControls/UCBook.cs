using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.UserControls
{
    public partial class UCBook : UserControl
    {
        public UCBook()
        {
            InitializeComponent();
        }

        private void LoadCategoriesToComboBox()
        {

        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            if (addCategory.ShowDialog() == DialogResult.OK) 
            {
                //Sau khi thêm xong thì reload combobox
                LoadCategoriesToComboBox();
            }
        }

        
    }
}
