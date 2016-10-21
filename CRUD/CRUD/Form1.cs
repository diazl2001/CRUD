using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Domain.Entity;
using Domain.Enums;


namespace CRUD
{
    public delegate void ProductInsertedEventHandler();

    public partial class Form1 : Form
    {
        public event ProductInsertedEventHandler NewProductInserted;

        public ProductController thisProductController;

        public Form1()
        {
            
            InitializeComponent();
            thisProductController = new ProductController();

            LoadComboType();            
            LoadGridWithProducts();
            
            //subscribe to even empleado inserted 
            this.NewProductInserted += this.OnProductInsertedM;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var thisProductContext = new ProductContext())
            {

                var thisProduct = new Product();
                thisProduct.SERVICE_NUMBER = txtSerialNo.Text;
                thisProduct.NAME = txtName.Text;
                thisProduct.TYPE =(TypeProd)Enum.Parse(typeof(TypeProd), cbType.SelectedItem.ToString());

                thisProductController.InsertarProduct(thisProduct);
                
                //Raise event 
                OnProductInserted();
            }
        }

        public void LoadGridWithProducts()
        {
            lbListOfProducts.DataSource = thisProductController.GetAllProducts();
        }

        public void LoadComboType()
        {
            cbType.Items.Add("A");
            cbType.Items.Add("B");
        }
        //event caller 
        public void OnProductInserted()
        {
            if (NewProductInserted != null)

                NewProductInserted();
        }
        //method to handle event 
        public void OnProductInsertedM()
        {
            LoadGridWithProducts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDeleteProd_Click(object sender, EventArgs e)
        {
            var thisProdt =(Product)lbListOfProducts.SelectedItem;
            thisProductController.DeleteProduct(thisProdt.ID);

            //Raise event 
            OnProductInserted();
        }

        private void lbListOfProducts_MouseClick(object sender, MouseEventArgs e)
        {
            var item = (Product) lbListOfProducts.SelectedItem;
            txtName.Text = item.NAME.ToString();
            txtSerialNo.Text = item.SERVICE_NUMBER.ToString();            
            cbType.SelectedItem = item.TYPE.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updateProduct = (Product)lbListOfProducts.SelectedItem;           

            updateProduct.NAME = txtName.Text;
            updateProduct.SERVICE_NUMBER = txtSerialNo.Text;
            updateProduct.TYPE = (TypeProd)Enum.Parse(typeof(TypeProd), cbType.SelectedItem.ToString());

            thisProductController.UpdateProduct(updateProduct);

            //Raise event 
            OnProductInserted();

        }
    }
}
