# How to apply alternate backcolor for the rows in both parent and child datagrid in winforms

This example illustrates how to apply alternate backcolor for the rows in both parent and child datagrid in winforms.

You can apply alternate back color to rows in both the parent and child grids by hooking the [QueryRowStyle](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_QueryRowStyle) event for both the child and parent DataGrid.

``` c#
this.sfDataGrid1.QueryRowStyle += ParentDataGrid_QueryRowStyle;
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
gridViewDefinition.DataGrid.QueryRowStyle += ChildDataGrid_QueryRowStyle;
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
```