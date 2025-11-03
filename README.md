# How to Apply Alternate Backcolor for the Rows in Both Parent and Child Grid in WinForms DataGrid?

This example illustrates how to apply alternate backcolor for the rows in both parent and child [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid).

You can apply alternate back color to rows in both the parent and child grids by hooking the [QueryRowStyle](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_QueryRowStyle) event for both the child and parent DataGrid.

#### C#

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

#### VB

``` vb
AddHandler Me.sfDataGrid1.QueryRowStyle, AddressOf ParentDataGrid_QueryRowStyle
Private Sub ParentDataGrid_QueryRowStyle(ByVal sender As Object, ByVal e As Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs)
    If sfDataGrid1.DetailsViewDefinitions.Count > 0 Then
        If e.RowType = Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow Then
            If (e.RowIndex / (sfDataGrid1.DetailsViewDefinitions.Count + 1)) Mod 2 = 0 Then
                e.Style.BackColor = Color.LightGreen
            Else
                e.Style.BackColor = Color.Yellow
            End If
        End If
    End If
End Sub

AddHandler gridViewDefinition.DataGrid.QueryRowStyle, AddressOf ChildDataGrid_QueryRowStyle
Private Sub ChildDataGrid_QueryRowStyle(ByVal sender As Object, ByVal e As Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs)
    If e.RowType = Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow Then
        If e.RowIndex Mod 2 = 0 Then
            e.Style.BackColor = Color.Yellow
        Else
            e.Style.BackColor = Color.LightGreen
        End If
    End If
End Sub
```

![DataGrid applied with alternate backcolor](DataGridWithAlternateBackColor.png)