# How to apply alternate backcolor for the rows in both parent and child grid in WinForms DataGrid (SfDataGrid) 

## Apply backcolor to rows in parent and child grid

You can apply alternate back color to rows in both the parent and child grids by hooking the [QueryRowStyle](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html?_ga=2.79238300.967019853.1668146580-766490130.1650530957&_gl=1*1hb2wcx*_ga*NzY2NDkwMTMwLjE2NTA1MzA5NTc.*_ga_WC4JKKPHH0*MTY2ODE1ODI2OC4yOTcuMS4xNjY4MTYwMjM5LjAuMC4w) event for both the child and parent DataGrid.

## C# 

```C#
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

## VB

```VB
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
