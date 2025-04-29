using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TransferObject;

namespace PresentationLayer.UserControls
{
    public partial class UCRule : UserControl
    {
        private RuleBL ruleBL = new RuleBL();

        public UCRule()
        {
            InitializeComponent();
            LoadRule();
            CustomizeColumnHeaders();
            SetPlaceholder();
        }

        public void LoadRule()
        {
            dgvRules.DataSource = ruleBL.GetRule();
        }

        private void ClearForm()
        {
            txtContent.Clear();
            txtQuantity.Clear();
        }

        private void CustomizeColumnHeaders()
        {
            if (dgvRules.Columns.Contains("RuleKey"))
                dgvRules.Columns["RuleKey"].HeaderText = "Quy định nhập";

            if (dgvRules.Columns.Contains("RuleValue"))
                dgvRules.Columns["RuleValue"].HeaderText = "Số lượng";
        }

        private TransferObject.Rule GetRuleFromField()
        {
            return new TransferObject.Rule(
                txtContent.Text,
                txtQuantity.Text
            );
        }

        private void dgvRules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRules.Rows[e.RowIndex];
                txtContent.Text = row.Cells["RuleKey"].Value.ToString();
                txtQuantity.Text = row.Cells["RuleValue"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TransferObject.Rule rule = GetRuleFromField(); // ← sửa tên đúng
            if (ruleBL.UpdateRule(rule))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadRule();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void SetPlaceholder()
        {
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Nhập quy định cần tra cứu";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            // Nếu đang là placeholder thì bỏ qua không tìm kiếm
            if (keyword == "Nhập quy định cần tra cứu")
            {
                return;
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                dgvRules.DataSource = new RuleBL().SearchRules(keyword);
            }
            else
            {
                // Nếu người dùng không nhập gì → load lại toàn bộ
                LoadRule();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Nhập quy định cần tra cứu")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.ForeColor = Color.Gray;
                txtSearch.Text = "Nhập quy định cần tra cứu";
            }
        }
    }
}
