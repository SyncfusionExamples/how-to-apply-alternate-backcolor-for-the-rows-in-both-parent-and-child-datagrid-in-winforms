#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.Input.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetailsView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SampleCustomization();

            this.sfDataGrid1.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Extended;
        }

        /// <summary>
        /// Sets the sample customization settings.
        /// </summary>
        private void SampleCustomization()
        {            
            OrderInfoRepository order = new OrderInfoRepository();
            List<OrderInfo> orderDetails = order.GetOrdersDetails(100);
            this.sfDataGrid1.DataSource = orderDetails;

            GridViewDefinition gridViewDefinition = new GridViewDefinition();
            gridViewDefinition.RelationalColumn = "OrderDetails";

            SfDataGrid childGrid = new SfDataGrid();
            childGrid.AutoGenerateColumns = false;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };
            childGrid.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID", NumberFormatInfo = nfi });
            childGrid.Columns.Add(new GridNumericColumn() { MappingName = "ProductID", HeaderText = "Product ID", NumberFormatInfo = nfi });
            childGrid.Columns.Add(new GridNumericColumn() { MappingName = "UnitPrice", HeaderText = "Unit Price", FormatMode = FormatMode.Currency });
            childGrid.Columns.Add(new GridNumericColumn() { MappingName = "Quantity" });
            childGrid.Columns.Add(new GridNumericColumn() { MappingName = "Discount", FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Percent });
            childGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID"});
            childGrid.Columns.Add(new GridDateTimeColumn() { MappingName = "OrderDate", HeaderText = "Order Date" });
            gridViewDefinition.DataGrid = childGrid;
            gridViewDefinition.DataGrid.QueryRowStyle += ChildDataGrid_QueryRowStyle;

            gridViewDefinition.DataGrid.CurrentCellKeyPress += DataGrid_CurrentCellKeyPress;

            this.sfDataGrid1.DetailsViewDefinitions.Add(gridViewDefinition);
            this.sfDataGrid1.QueryRowStyle += ParentDataGrid_QueryRowStyle;
        }

        void DataGrid_CurrentCellKeyPress(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellKeyPressEventArgs e)
        {
            var dataGrid = sender as SfDataGrid;
            if (dataGrid.CurrentCell.Column.MappingName == "Name")
            {
                var check = dataGrid.CurrentCell.CellRenderer.CurrentCellRendererElement;
                if (check != null)
                {
                    if (dataGrid.CurrentCell.CellRenderer.CurrentCellRendererElement.Text.Length >= 6 && !char.IsControl(e.KeyPressEventArgs.KeyChar))
                    {
                        e.KeyPressEventArgs.Handled = true;
                    }
                }
            }
        }

        void ParentDataGrid_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (sfDataGrid1.DetailsViewDefinitions.Count > 0)
            {
                if (e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
                {
                    if ((e.RowIndex / (sfDataGrid1.DetailsViewDefinitions.Count + 1)) % 2 == 0)
                        e.Style.BackColor = Color.LightGreen;
                    else
                        e.Style.BackColor = Color.Yellow;
                }
            }
        }

        void ChildDataGrid_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if(e.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.Yellow;
                else
                    e.Style.BackColor = Color.LightGreen;
            }
        }
    }
}
