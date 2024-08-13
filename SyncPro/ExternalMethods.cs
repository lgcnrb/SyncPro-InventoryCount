using DocumentFormat.OpenXml.Packaging;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

public static class ExternalMethods
{
    public static void ExportToExcel(DataGridView dataGridView, string defaultFileName)
    {
        // Excel uygulamasını oluştur
        Excel.Application excelApp = new Excel.Application();
        excelApp.Visible = false; // Excel uygulaması görünmez olacak

        // Yeni bir Excel çalışma kitabı oluştur
        Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
        Excel.Worksheet worksheet = workbook.ActiveSheet;

        try
        {
            // DataGridView'deki verileri Excel'e aktar
            for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Excel dosyasını kaydet
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Save Excel file",
                FileName = defaultFileName
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Data exported to Excel successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error exporting data to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // Excel uygulamasını kapat
            workbook.Close(false);
            excelApp.Quit();

            // COM nesnelerini serbest bırak
            ReleaseComObject(worksheet);
            ReleaseComObject(workbook);
            ReleaseComObject(excelApp);
        }
    }

    private static void ReleaseComObject(object obj)
    {
        if (obj != null && System.Runtime.InteropServices.Marshal.IsComObject(obj))
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        }
    }
    public static void ExportToExcelTable(DataTable dataTable, string defaultFileName)
    {
        // Excel uygulamasını oluştur
        Excel.Application excelApp = new Excel.Application();
        excelApp.Visible = false; // Excel uygulaması görünmez olacak

        // Yeni bir Excel çalışma kitabı oluştur
        Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
        Excel.Worksheet worksheet = workbook.ActiveSheet;

        try
        {
            // DataTable'deki sütun başlıklarını Excel'e aktar
            for (int i = 1; i < dataTable.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataTable.Columns[i - 1].ColumnName;
            }

            // DataTable'deki verileri Excel'e aktar
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                }
            }

            // Excel dosyasını kaydet
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Save Excel file",
                FileName = defaultFileName
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Data exported to Excel successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error exporting data to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // Excel uygulamasını kapat
            workbook.Close(false);
            excelApp.Quit();

            // COM nesnelerini serbest bırak
            ReleaseComObject(worksheet);
            ReleaseComObject(workbook);
            ReleaseComObject(excelApp);
        }
    }

}
