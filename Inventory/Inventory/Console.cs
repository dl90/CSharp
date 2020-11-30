using System;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Console : Form
    {
        private int childFormNumber = 0;

        public Console()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AlreadyOpen<T>()
        {
            bool alreadyOpened = false;
            foreach(Form child in this.MdiChildren)
            {
                if (child is T) alreadyOpened = true;
            }
            return alreadyOpened;
        }

        private void AddNewUserMenuItem_Click(object sender, EventArgs e)
        {
            bool alreadyOpen = AlreadyOpen<AddUserForm>();
            if (!alreadyOpen)
            {
                AddUserForm form = new AddUserForm();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void InventoryMenuManage_Click(object sender, EventArgs e)
        {
            bool alreadyOpen = AlreadyOpen<InventoryForm>();
            if (!alreadyOpen)
            {
                InventoryForm form = new InventoryForm();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void ViewUsersMenuItem_Click(object sender, EventArgs e)
        {
            bool alreadyOpen = AlreadyOpen<UsersForm>();
            if (!alreadyOpen)
            {
                UsersForm form = new UsersForm();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void InventoryMenuPurchase_Click(object sender, EventArgs e)
        {
            bool alreadyOpen = AlreadyOpen<PurchaseForm>();
            if (!alreadyOpen)
            {
                PurchaseForm form = new PurchaseForm();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void InventoryMenuPurchaseHistory_Click(object sender, EventArgs e)
        {
            bool alreadyOpen = AlreadyOpen<PurchaseHistoryForm>();
            if (!alreadyOpen)
            {
                PurchaseHistoryForm form = new PurchaseHistoryForm();
                form.MdiParent = this;
                form.Show();
            }
        }
    }
}
