using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using Excel;

namespace BigDataSmartSolutions.Core.Util
{
    public static class Excel
    {
        public static bool IsValido(HttpPostedFileBase file)
        {
            if(file.ContentLength < 0)
                throw new Exception("Arquivo corrompido tente novamente.");
            
            if(file.ContentType != "application/octet-stream")
                throw new Exception("Arquivo inválido.");

            var extension = Path.GetExtension(file.FileName);
            if (extension == null || (extension.ToLower() != ".xls" && extension.ToLower() != ".xlsx"))
                throw new Exception("Formato inválido");

            return true;
        }

        public static string ExcelToCsv(string path, HttpPostedFileBase file)
        {
            if (file.FileName != null)
            {
                var filePath = Path.Combine(path, Path.GetFileName(file.FileName));

                file.SaveAs(filePath);
                
                FileStream stream = new FileStream(filePath, FileMode.Open);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                DataSet result = excelReader.AsDataSet();

                return DataTableToCsv(result.Tables[0]);
            }

            return "";
        }

        private static string DataTableToCsv(DataTable dataTable)
        {
            StringBuilder sb = new StringBuilder();
            var sep = ";";
            var qtdColumns = dataTable.Columns.Count;

            for (int x = 0; x < qtdColumns; x++)
            {
                sb.Append(dataTable.Columns[x]);

                if(x < qtdColumns - 1)
                    sb.Append(sep);
            }

            sb.AppendLine();
            foreach (DataRow row in dataTable.Rows)
            {
                for (int x = 0; x < qtdColumns; x++)
                {
                    sb.Append(row[x]);

                    if (x < qtdColumns - 1)
                        sb.Append(sep);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
