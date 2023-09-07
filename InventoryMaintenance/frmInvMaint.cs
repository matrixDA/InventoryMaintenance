using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmInvMaint : Form
    {
        public frmInvMaint()
        {
            InitializeComponent();
        }

        // Add a statement here that declares the list of items.
        private List<InvItem> invItems = null;

        private void frmInvMaint_Load(object sender, EventArgs e)
        {
            // Add a statement here that gets the list of items.
            invItems = InvItemDB.GetItems();
            FillItemListBox();
        }

        private void FillItemListBox()
        {
            lstItems.Items.Clear();
            // Add code here that loads the list box with the items in the list.
            foreach (InvItem item in invItems)
            {
                lstItems.Items.Add(item.GetDisplayedText("\t"));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add code here that creates an instance of the New Item form
            frmNewItem frmNewItem = new();

            // and then gets a new item from that form.
            InvItem invItem = frmNewItem.GetNewItem();
            if (invItem != null)
            {
                invItems.Add(invItem);
                InvItemDB.SaveItems(invItems);

            }
            FillItemListBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;
            if (i != -1)
            {
                // Add code here that displays a dialog box to confirm
                InvItem item = invItems[i];

                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete " + item.Description,
                    "Confirm Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // the deletion and then removes the item from the list,
                    invItems.Remove(item);
                }
                // saves the list of products, and refreshes the list box
                InvItemDB.SaveItems(invItems);
                FillItemListBox();

                // if the deletion is confirmed.
                DialogResult confimed = MessageBox.Show("Sucessfully deleted item", "Deletion Sucessful");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
